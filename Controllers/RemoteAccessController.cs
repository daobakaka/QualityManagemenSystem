using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            [FromQuery] string dateRange = "",
            [FromQuery] string faultMode = "",
            [FromQuery] string faultCode = "",
            [FromQuery] string breakpointTime = "",
            [FromQuery] string vehicleNumber = "")
        {
            if (string.IsNullOrEmpty(oldMaterialCode))
            {
                return BadRequest("Invalid OldMaterialCode");
            }

            // 初始化查询
            var query = _context.DailyServiceReviewFormQueries
                .Where(e => e.OldMaterialCode == oldMaterialCode);

            // 用于存储处理后的日期
            string? startDateStr = null;
            string? endDateStr = null;

            if (!string.IsNullOrEmpty(dateRange))
            {
                var dates = dateRange.Split('-');

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
                query = query.Where(e => e.FaultCode.Contains(faultCode));
            }

            // 处理断点时间
            if (!string.IsNullOrEmpty(breakpointTime))
            {
                if (DateTime.TryParseExact(breakpointTime, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var parsedBreakpointDate))
                {
                    // 转换为YYYYMM格式
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

            // 处理车辆号
            if (!string.IsNullOrEmpty(vehicleNumber))
            {
                query = query.Where(e => e.VAN.Contains(vehicleNumber)||e.VIN.Contains(vehicleNumber));
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
                    
                })
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound("No data found for the provided parameters.");
            }

            return Ok(data);
        }

        [HttpGet("vehiclebasicinfodata")]
        public async Task<IActionResult> GetVehicleBasicInfoData([FromQuery] string fdp = "")
        {
            // 定义默认日期范围
            DateTime defaultStartDate = new DateTime(2015, 1, 1);
            DateTime defaultEndDate = new DateTime(2030, 12, 31);

            // 初始化查询
            var query = _context.VehicleBasicInfos.AsQueryable();

            // 筛选FDP
            if (!string.IsNullOrEmpty(fdp))
            {
                query = query.Where(v => v.FDP.Contains(fdp));
            }

            // 获取所有数据
            var allData = await query.ToListAsync();

            // 筛选销售日期在2015年到2030年之间
            var filteredData = allData
                .Where(v => DateTime.TryParse(v.SalesDate, out var salesDateValue) &&
                            salesDateValue >= defaultStartDate &&
                            salesDateValue <= defaultEndDate)
                .Select(v => new
                {
                    v.ID,
                    v.ShortVin,
                    v.VIN,
                    v.VAN,
                    v.FDP,
                    v.AnnouncementModel,
                    v.ProductionDate,
                    v.SalesDate,
                    v.EngineNumber,
                    v.ClaimDate,
                    v.ExportStatus,
                    v.EngineModel,
                    v.SsvaOrSva,
                    v.InternalAnnouncemen,
                    v.SeriesDescription,
                    v.ProductionMouth,
                    v.Series,
                    v.Emissions
                });

            if (!filteredData.Any())
            {
                return NotFound("No data found for the provided FDP.");
            }

            return Ok(filteredData);
        }


    }
}
