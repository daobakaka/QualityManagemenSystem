﻿using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Irony.Parsing;

namespace WebWinMVC.Controllers
{
    [Route("queryAPI/[controller]")]
    [ApiController]
    public class RemoteAccessController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;

        public RemoteAccessController(JRZLWTDbContext context)
        {
            _context = context;
        }

        [HttpGet("dailyqualitydata")]
        public async Task<IActionResult> GetDailyQualityData(
            [FromQuery] string oldMaterialCode,
            [FromQuery] string ApprovalDate = "",
            [FromQuery] string faultMode = "",
            [FromQuery] string faultCode = "",
            [FromQuery] string ManufacturingMonth = "",
            [FromQuery] string VehicleIdentification = "")
        {
            if (string.IsNullOrEmpty(oldMaterialCode))
            {
                return BadRequest("Invalid OldMaterialCode");
            }

            // 初始化查询
            var query = _context.DailyServiceReviewFormQueries
                .Where(e => e.OldMaterialCode == oldMaterialCode)
                .Where(e => e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务")
                .Where(e => e.ResponsibilitySourceIdentifier == "是")
                .Where(e => e.RepairMethod == "更换" || e.RepairMethod == "维修")
                .Where(e => e.MaterialType == "物料");
            // 用于存储处理后的日期
            string? startDateStr = null;
            string? endDateStr = null;

            if (!string.IsNullOrEmpty(ApprovalDate))
            {
                var dates = ApprovalDate.Split('-');

                if (dates.Length == 1)
                {
                    // 只有一个日期，作为开始日期
                    if (DateTime.TryParseExact(dates[0], "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var startDate))
                    {
                        startDateStr = startDate.ToString("yyyy-MM-dd"); // 转换为 yyyy-MM-dd 格式
                    }
                }
                else if (dates.Length == 2)
                {
                    // 有开始和结束日期
                    if (DateTime.TryParseExact(dates[0], "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var startDate) &&
                        DateTime.TryParseExact(dates[1], "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var endDate))
                    {
                        startDateStr = startDate.ToString("yyyy-MM-dd"); // 转换为 yyyy-MM-dd 格式
                        endDateStr = endDate.ToString("yyyy-MM-dd");     // 转换为 yyyy-MM-dd 格式
                    }
                }

                if (!string.IsNullOrEmpty(startDateStr))
                {
                    if (!string.IsNullOrEmpty(endDateStr))
                    {
                        query = query.Where(e => e.ApprovalDate.CompareTo(startDateStr) >= 0 &&
                                                 e.ApprovalDate.CompareTo(endDateStr) <= 0);
                    }
                    else
                    {
                        query = query.Where(e => e.ApprovalDate.CompareTo(startDateStr) == 0);
                    }
                }
            }

            // 处理故障模式

            // 处理故障码
            if (!string.IsNullOrEmpty(faultCode))
            {
                Console.WriteLine(faultCode); // 打印调试信息

                // 使用 % 通配符来进行 LIKE 查询
                var faultCodePattern = $"%{faultCode}%";
                query = query.Where(e => EF.Functions.Like(e.FaultCode, faultCodePattern));
            }

            // 处理断点时间
            if (!string.IsNullOrEmpty(ManufacturingMonth))
            {
                if (DateTime.TryParseExact(ManufacturingMonth, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var parsedBreakpointDate))
                {
                    // 将传入的日期增加一个月，即模糊认为 在制造月的后面
                    parsedBreakpointDate.AddMonths(1);
                    var yearMonthStr = parsedBreakpointDate.ToString("yyyyMM");
                    var cutoffDate = new DateTime(2030, 1, 1); // 设置截止日期为2030年
                    var cutoffYearMonth = cutoffDate.ToString("yyyyMM");

                    // 筛选制造月大于等于传入的年份和月份，并且不超过2030年
                    query = query.Where(e => string.Compare(e.ManufacturingMonth, yearMonthStr) >= 0 &&
                                             string.Compare(e.ManufacturingMonth, cutoffYearMonth) <= 0);
                }
                else
                {
                    return BadRequest("Invalid breakpointTime format. Expected format is YYMMDD.");
                }
            }

            if (!string.IsNullOrEmpty(VehicleIdentification))
            {
                // 分隔字符串并去除空格
                //  Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + VehicleIdentification);
                var vehicleNumbers = VehicleIdentification.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //  Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + vehicleNumbers);
                // 查询所有对应的 FDP 码
                // 从数据库中查询所有数据到内存
                var allData = await query
                    .ToListAsync(); // 使用 ToListAsync() 来加载数据到内存中

                // 在内存中筛选对应的 FDP 码
                var fdpCodes = allData
                    .Where(e => vehicleNumbers.Any(vn => e.VAN.Contains(vn) || e.VIN.Contains(vn)))
                    .Select(e => e.FDP)
                    .Distinct()
                    .ToList(); // 这里使用 ToList()，因为数据已在内存中


                // 基于 FDP 码进行 OR 筛选
                query = query.Where(e => fdpCodes.Contains(e.FDP));
            }

            // 获取数据
            var data = await query
                .Select(e => new
                {
                    e.ResponsibilitySourceSupplierName,
                    e.VehicleType,//车系描述
                    e.FDP,
                    e.InternalModelCode,
                    e.VAN,
                    e.VIN,
                    e.ManufacturingMonth,
                    e.SalesDate,//生产销售数量需要访问基础表
                    e.Province,
                    e.OutboundServiceLocation,//或添加详细信息外出服务地点
                    e.DrivingMileageKM,
                    e.FaultDescription,
                    e.FaultCode,
                    e.FaultCodeDescription,
                    e.FilteredVehicleModel,

                })
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound("No data found for the provided parameters.");
            }

            return Ok(data);
        }


        [HttpGet("vehiclebasicinfodata")]
        public async Task<IActionResult> GetVehicleBasicInfoData([FromQuery] string VehicleIdentification = "")
        {
            // 定义默认日期范围
            DateTime defaultStartDate = new DateTime(2015, 1, 1);
            DateTime defaultEndDate = new DateTime(2030, 12, 31);

            // 初始化查询
            var query = _context.VehicleBasicInfos.AsQueryable();

            // 如果提供了 VehicleIdentification，则进行筛选
            if (!string.IsNullOrEmpty(VehicleIdentification))
            {
                // 分隔字符串并去除空格
                var vehicleNumbers = VehicleIdentification.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // 从数据库中查询所有数据到内存
                var allData = await query.ToListAsync(); // 使用 ToListAsync() 来加载数据到内存中

                // 在内存中筛选对应的 FDP 码
                var fdpCodes = allData
                    .Where(e => vehicleNumbers.Any(vn => e.VAN.Contains(vn) || e.VIN.Contains(vn)))
                    .Select(e => e.FDP)
                    .Distinct()
                    .ToList(); // 这里使用 ToList()，因为数据已在内存中

                // 基于 FDP 码进行 OR 筛选
                query = query.Where(e => fdpCodes.Contains(e.FDP));
            }

            // 获取所有数据
            var filteredData = await query.ToListAsync();

            // 满足FDP的行数
            int totalFdpCount = filteredData.Count;

            // 满足销售日期在2015年到2030年之间的行数
            int filteredDateCount = filteredData
                .Count(v => DateTime.TryParse(v.SalesDate, out var salesDateValue) &&
                            salesDateValue >= defaultStartDate &&
                            salesDateValue <= defaultEndDate);

            // 返回结果
            var result = new
            {
                TotalFdpCount = totalFdpCount,
                FilteredDateCount = filteredDateCount
            };

            return Ok(result);
        }

    }
}
