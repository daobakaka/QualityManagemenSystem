using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Diagnostics;
using WebWinMVC.Models;

namespace WebWinMVC.Controllers
{
    [Route("queryAPI/[controller]")]
    [ApiController]
    public class RemoteAccessController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;
        private readonly ILogger<RemoteAccessController> _logger;
       // private readonly TaskCompletionSource<bool> _fdpCodesInitialized = new TaskCompletionSource<bool>();

        public RemoteAccessController(JRZLWTDbContext context, ILogger<RemoteAccessController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("dailyqualitydata")]
        public async Task<IActionResult> GetDailyQualityData(
            [FromQuery] string OldMaterialCode,
            [FromQuery] string ApprovalDate = "",
            [FromQuery] string FaultMode = "",
            [FromQuery] string FaultCode = "",
            [FromQuery] string ManufacturingMonth = "",
            [FromQuery] string VehicleIdentification = "")
        {

            _logger.LogError("++进入一页纸及查询方法");
            if (string.IsNullOrEmpty(OldMaterialCode))
            {
                return BadRequest("Invalid OldMaterialCode");
            }
            var _fdpCodes = new HashSet<string>();
            _fdpCodes.Clear();
            var query = _context.DailyServiceReviewFormQueries
                .Where(e => e.OldMaterialCode == OldMaterialCode)
                .Where(e => e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务")
                .Where(e => e.ResponsibilitySourceIdentifier == "是")
                .Where(e => e.RepairMethod == "更换" || e.RepairMethod == "维修")
                .Where(e => e.MaterialType == "物料");



            // 用于存储处理后的日期


            if (!string.IsNullOrEmpty(ApprovalDate))
            {
                string? startDateStr = null;
                string? endDateStr = null;
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
            if (!string.IsNullOrEmpty(FaultCode))
            {
                Console.WriteLine(FaultCode); // 打印调试信息

                // 使用 % 通配符来进行 LIKE 查询
                var faultCodePattern = $"%{FaultCode}%";
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
            //放到这里可以减少筛选量

            if (!string.IsNullOrEmpty(VehicleIdentification))
            {
                var vehicleNumbers = VehicleIdentification.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + vehicleNumbers);
                //for (int i = 0; i < vehicleNumbers.Length; i++)
                //{
                //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + vehicleNumbers[i]);

                //}
                //查询所有对应的 FDP 码
                //从数据库中查询所有数据到内存
                var allData = await query
                    .ToListAsync(); // 使用 ToListAsync() 来加载数据到内存中

                // 在内存中筛选对应的 FDP 码
                foreach (var fdpCode in allData
                  .Where(e => vehicleNumbers.Any(vn => e.VAN.Contains(vn) || e.VIN.Contains(vn)))
                 .Select(e => e.FDP))
                {
                    _fdpCodes.Add(fdpCode); // HashSet 会自动去重
                }
                foreach (string fdpCode in _fdpCodes)
                {
                    Console.WriteLine("++++++start++not empty to add HASEt" + fdpCode);
                }
                query = query.Where(e => _fdpCodes.Contains(e.FDP));
            }
            else
            {
                var tempData = await query.ToListAsync();
                foreach (var fdpCode in tempData.Select(e => e.FDP))
                {
                    _fdpCodes.Add(fdpCode); // HashSet 自动处理重复

                }
                foreach (string fdpCode in _fdpCodes)
                {
                    Console.WriteLine("++++++start++is empty    to add HASEt" + fdpCode);
                }
            }
            var filteredInfo = await GetFilteredVehicleBasicInfoData(_fdpCodes, ManufacturingMonth);
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

            return Ok(new
            {
                Data = data,
                FilteredInfo = filteredInfo // 包括从 GetFilteredVehicleBasicInfoData 返回的结果
            });
        }
        private async Task<dynamic> GetFilteredVehicleBasicInfoData(HashSet<string> _fdpCodes,string ManufacturingMonth)
        {
            // 定义默认日期范围
            DateTime defaultStartDate = new DateTime(2015, 1, 1);
            DateTime defaultEndDate = new DateTime(2030, 12, 31);

            // 初始化查询
            var query = _context.VehicleBasicInfos.AsQueryable();

            query = query.Where(e => _fdpCodes.Contains(e.FDP));

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
                    query = query.Where(e => string.Compare(e.ProductionDate, yearMonthStr) >= 0 &&
                                             string.Compare(e.ProductionDate, cutoffYearMonth) <= 0);
                }
                else
                {
                    return BadRequest("Invalid breakpointTime format. Expected format is YYMMDD.");
                }
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
            return new
            {
                TotalFdpCount = totalFdpCount,
                FilteredDateCount = filteredDateCount
            };
        }

        [HttpGet("vehiclebasicinfodata")]
        public async Task<IActionResult> GetVehicleBasicInfoData([FromQuery] string VehicleIdentification = "")
        {
                return Ok("VehicleIdentification"+ VehicleIdentification);


            var _fdpCodes = new HashSet<string>();
            // 定义默认日期范围
            DateTime defaultStartDate = new DateTime(2015, 1, 1);
            DateTime defaultEndDate = new DateTime(2030, 12, 31);

            // 初始化查询
            var query = _context.VehicleBasicInfos.AsQueryable();

            // 如果提供了 VehicleIdentification，则进行筛选
            if (!string.IsNullOrEmpty(VehicleIdentification))
            {
                // 分隔字符串并去除空格
                //  Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + VehicleIdentification);
                _fdpCodes.Clear();
                var vehicleNumbers = VehicleIdentification.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + vehicleNumbers);
                for (int i = 0; i < vehicleNumbers.Length; i++)
                {
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++" + vehicleNumbers[i]);

                }
                //查询所有对应的 FDP 码
                //从数据库中查询所有数据到内存
                var allData = await query
                    .ToListAsync(); // 使用 ToListAsync() 来加载数据到内存中

                // 在内存中筛选对应的 FDP 码
                foreach (var fdpCode in allData
                  .Where(e => vehicleNumbers.Any(vn => e.VAN.Contains(vn) || e.VIN.Contains(vn)))
                 .Select(e => e.FDP))
                {
                    _fdpCodes.Add(fdpCode); // HashSet 会自动去重
                }

                query = query.Where(e => _fdpCodes.Contains(e.FDP));
            }

            foreach (string fdpCode in _fdpCodes)
            {
                Console.WriteLine("++++++start to add HASEt"+fdpCode);
            }
            query = query.Where(e => _fdpCodes.Contains(e.FDP));
            

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
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++"+result.TotalFdpCount+"and"+result.FilteredDateCount);
            return Ok(result);
        }


        [HttpPost("dailyqualitydataforsil")]
        [ValidateAntiForgeryToken] // 添加防伪令牌验证
        public async Task<IActionResult> PostDailyQualityDataForSIL(
        [FromForm] string OldMaterialCode,
        [FromForm] string VehicleIdentification,
        [FromForm] string ApprovalDate = "",
        [FromForm] string FaultMode = "",
        [FromForm] string FaultCode = "",
        [FromForm] string ManufacturingMonth = "")
        {
            // 验证输入
        //    public async Task<IActionResult> GetDailyQualityData(
        //[FromQuery] string OldMaterialCode,
        //[FromQuery] string ApprovalDate = "",
        //[FromQuery] string FaultMode = "",
        //[FromQuery] string FaultCode = "",
        //[FromQuery] string ManufacturingMonth = "",
        //[FromQuery] string VehicleIdentification = "")
            if (string.IsNullOrEmpty(OldMaterialCode) || string.IsNullOrEmpty(VehicleIdentification))
            {
                return BadRequest("Invalid input parameters.");
            }
            _logger.LogError("++++++++++++++++++++进入POST生成SIL方法======================================" + VehicleIdentification);
            //casue the pre logic has changed,the code here would add filter that switch filterdVehicleType and shortCode
            var query = _context.DailyServiceReviewFormQueries
                .Where(e => e.OldMaterialCode == OldMaterialCode)
                .Where(e => e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务")
                .Where(e => e.ResponsibilitySourceIdentifier == "是")
                .Where(e => e.RepairMethod == "更换" || e.RepairMethod == "维修")
                .Where(e => e.MaterialType == "物料")
                .Where(e => e.VAN.Contains(VehicleIdentification) || e.VIN.Contains(VehicleIdentification));


            if (!string.IsNullOrEmpty(ApprovalDate))
            {
                string? startDateStr = null;
                string? endDateStr = null;
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
            if (!string.IsNullOrEmpty(FaultCode))
            {
                Console.WriteLine(FaultCode); // 打印调试信息

                // 使用 % 通配符来进行 LIKE 查询
                var faultCodePattern = $"%{FaultCode}%";
                query = query.Where(e => EF.Functions.Like(e.FaultCode, faultCodePattern));
            }
            // 处理断点时间，
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

            // 获取数据
            var data = await query
                .Select(e => new
                {
                    e.ServiceOrder,
                    e.WorkOrderCreationDate,
                    e.Province,
                    e.ServiceStationName,
                    e.VAN,
                    e.VIN,
                    e.OldMaterialCode,
                    e.OldMaterialDescription,
                    e.Quantity,
                    e.LocationCode,
                    e.LocationCodeDescription,
                    e.FaultCode,
                    e.FaultCodeDescription,
                    e.FaultDescription,
                    e.DrivingMileageKM,
                    e.FDP,
                    e.VehicleType,
                    e.SalesDate
                })
                .ToListAsync();

            // 确保有数据并只选择第一项
            var firstData = data.FirstOrDefault();
            if (firstData == null)
            {
                return NotFound("No data found for the provided parameters.");
            }

            // 创建要插入的数据对象
            var newData = new SILSimulationTable
            {
                LocationCode = firstData.LocationCode ?? "NIL",
                OldMaterialCode = firstData.OldMaterialCode ?? "NIL",
                Province = firstData.Province ?? "NIL",
                FailurePartCount = "0", // 确保为0
                FaultCode = firstData.FaultCode ?? "NIL",
                FaultCodeDescription = firstData.FaultCodeDescription ??"NIL",
                LocationCodeDescription = firstData.LocationCodeDescription ??"NIL",
                OldMaterialCodeDescription=firstData.OldMaterialDescription ??"NIL",
                Title = $"F100-{(firstData.LocationCodeDescription ?? "NIL")}-{(firstData.OldMaterialDescription ?? "NIL")}-{(firstData.FaultCodeDescription ?? "NIL")}",
                VehicleModel = firstData.VehicleType ?? "NIL",
                PurchaseTime = firstData.SalesDate ?? "NIL",
                FaultTime = firstData.WorkOrderCreationDate ?? "NIL",
                RepairTime = firstData.WorkOrderCreationDate ?? "NIL",
                VAN = firstData.VAN ?? "NIL",
                ChassisNumber = firstData.VIN ?? "NIL",
                Inspector = firstData.ServiceStationName ?? "NIL",
                City = firstData.ServiceStationName ?? "NIL",
                InitialFaultAnalysis = firstData.FaultDescription ?? "NIL",
                RepairProcessAndEffect = firstData.FaultDescription ?? "NIL",
                FaultLevel = "正常", // 直接初始化为NIL
                Reporter = firstData.ServiceStationName, // 初始化
                ReporterPhone = HttpContext.Session.GetString("Phone"), // 初始化
                TTF = "0",
                //ResponsiblePerson ="郭鹏飞",
                //ResponsibleDepartment="采购部"
                Manager = HttpContext.Session.GetString("Name"),
                Creator = HttpContext.Session.GetString("Name"),
                StartTime = DateTime.Now.ToString("yyMMdd"),// 设置开始时间为当前时间，格式为YYMMDD
                StageStatus = "执行中",
                Status = "0/6",
                PreventiveMeasures = "维修或更换",
                VehicleStatus="终端",
                InspectorPhone= "02365892154",
                FaultDescription =firstData.FaultDescription??"NIL",

            };

            // 将新数据保存到数据库
            await _context.SILSimulationTables.AddAsync(newData);
            await _context.SaveChangesAsync();

            // 获取当前生成的 ID
            var currentId = newData.ID;

            // 更新通知单号和 PSQ编号
            newData.NotificationNumber = $"{DateTime.UtcNow.Ticks}-{currentId}"; // 使用时间戳和 ID
            newData.PSQNumber = "MD" + newData.NotificationNumber; // PSQ编号为 "MD" + 通知单号

            // 再次保存更改
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Data = newData,
            });
        }

    }
}
