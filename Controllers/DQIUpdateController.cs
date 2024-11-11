using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWinMVC.Data;
using WebWinMVC.Models;

namespace WebWinMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DQIUpdateController : ControllerBase
    {
        private readonly JRZLWTDbContext _dbContext;
        private readonly ILogger<DQIUpdateController> _logger;

        public DQIUpdateController(ILogger<DQIUpdateController> logger, JRZLWTDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("MakeDailyQualityQueryTable")]
        public async Task<IActionResult> MakeDailyQualityQueryTable([FromQuery] DataOperation operation)
        {
            var dbDailyServiceReviewTable = _dbContext.DailyServiceReviewForms;
            var dbDailyServiceReviewQueryTable = _dbContext.dailyServiceReviewFormQueryTemps;
            var dbVehicleBasicInfo = _dbContext.VehicleBasicInfos;

            // 加载需要处理的表
            var dbDailyServiceReviewForms = await dbDailyServiceReviewTable.ToListAsync();
            var dbVehicleBasicInfos = await dbVehicleBasicInfo.ToListAsync(); // 只查询一次

            // 处理 DailyServiceReviewForms 和 VehicleBasicInfos 的匹配
            var dailyQualityQueryEntries = dbDailyServiceReviewForms
                .Select(d =>
                {
                    // 使用 dbVehicleBasicInfos 临时存储已查询的数据
                    var vehicle = dbVehicleBasicInfos.FirstOrDefault(v => v.VAN == d.VAN);
                    var vehicleModelCache = !string.IsNullOrEmpty(d?.NoticeVehicleModel)
                                  ? d.NoticeVehicleModel.Substring(0, 3) : "NIL";
                    var emissionCache = d?.NoticeVehicleModel.Length > 5 ? d.NoticeVehicleModel.Substring(5, 1) : "NIL";
                    var fuelCache = emissionCache != "NIL"
                                ? (emissionCache == "0" || emissionCache == "1" ? "new" : "traditional"): "NIL";
                    var manufacturingMonthCache = vehicle?.ProductionDate != null ?
                      DateTime.TryParse(vehicle.ProductionDate, out var productionDate)
                      ? productionDate.ToString("yyyy-MM")
                                : "0"
                                : "0";//转换为YYYY-MM 格式
                    var salesDateCache = vehicle?.SalesDate;
                    int misCache = CalculateMis(d?.ServiceOrderCreationDate, vehicle?.SalesDate);
                    int misIntervalCache = misCache < 0 ? -1 : misCache switch
                    {
                        <= 3 => 3,   // 小于等于 3 的值
                        <= 6 => 6,   // 小于等于 6 的值
                        <= 12 => 12, // 小于等于 12 的值
                        <= 24 => 24, // 小于等于 24 的值
                        <= 36 => 36, // 小于等于 36 的值
                        <= 48 => 48, // 小于等于 48 的值
                        _ => 0       // 大于 48 的值
                    };

                    var vehicleFiterCache = (vehicleModelCache, fuelCache) switch
                    {
                        ("CQ1", "traditional") or ("CQ4", "traditional") => "传统燃油公路",
                        ("CQ3", "traditional") or ("CQ5", "traditional") => "传统燃油工程",
                        ("CQ1", "new") or ("CQ4", "new") => "新能源公路",
                        ("CQ3", "new") or ("CQ5", "new") => "新能源工程",
                        _ => "其他"
                    };

                    // 如果没有匹配项则跳过
                    if (vehicle == null) return null;
                    return new DailyServiceReviewFormQueryTemp
                    {
                       
                        ServiceOrder = d.ServiceOrder,
                        ServiceOrderStatus = d.ServiceOrderStatus,
                        ServiceOrderTotalPrice = d.ServiceOrderTotalPrice,
                        WorkOrderNumber = d.WorkOrderNumber,
                        WorkOrderCreationDate = d.WorkOrderCreationDate,
                        WorkOrderType = d.WorkOrderType,
                        DepartureTime = d.DepartureTime,
                        CarPickupTime = d.CarPickupTime,
                        WorkOrderRepairEndTime = d.WorkOrderRepairEndTime,
                        WorkOrderRepairAccount = d.WorkOrderRepairAccount,
                        OutboundServiceLocation = d.OutboundServiceLocation,
                        OutboundMileage = d.OutboundMileage,
                        Province = d.Province,
                        ServiceStation = d.ServiceStation,
                        ServiceStationName = d.ServiceStationName,
                        NoticeVehicleModel = d.NoticeVehicleModel,
                        VAN = d.VAN,
                        OldMaterialCode = d.OldMaterialCode,
                        OldMaterialDescription = d.OldMaterialDescription,
                        NewMaterialCode = d.NewMaterialCode,
                        NewMaterialDescription = d.NewMaterialDescription,
                        RepairMethod = d.RepairMethod,
                        SupplyMethod = d.SupplyMethod,
                        Quantity = d.Quantity,
                        OldPartReturnStatus = d.OldPartReturnStatus,
                        ResponsibilitySourceIdentifier = d.ResponsibilitySourceIdentifier,
                        ResponsibilitySourceSupplier = d.ResponsibilitySourceSupplier,
                        SupplierShortCode = d.SupplierShortCode,
                        ResponsibilitySourceSupplierName = d.ResponsibilitySourceSupplierName,
                        LinePrice = d.LinePrice,
                        ActualAmount = d.ActualAmount,
                        MaterialMarkupCoefficient = d.MaterialMarkupCoefficient,
                        LaborRegionCoefficient = d.LaborRegionCoefficient,
                        LaborColdClimateCoefficient = d.LaborColdClimateCoefficient,
                        LaborQualityCoefficient = d.LaborQualityCoefficient,
                        LocationCode = d.LocationCode,
                        LocationCodeDescription = d.LocationCodeDescription,
                        FaultCode = d.FaultCode,
                        FaultCodeDescription = d.FaultCodeDescription,
                        FaultDescription = d.FaultDescription,
                        ServiceCategory = d.ServiceCategory,
                        ServiceOrderCreationDate = d.ServiceOrderCreationDate,
                        FDP = d.FDP,
                        SpecialAuthorizationCode = d.SpecialAuthorizationCode,
                        WBS = d.WBS,
                        DrivingMileageKM = d.DrivingMileageKM,
                        OutboundRescueLicensePlate1 = d.OutboundRescueLicensePlate1,
                        OutboundRescueLicensePlate2 = d.OutboundRescueLicensePlate2,
                        ApprovalDate = d.ApprovalDate,

                        //--新增加的列
                        ManufacturingMonth=manufacturingMonthCache,
                        SalesDate = salesDateCache,
                        MIS=misCache.ToString(),
                        VehicleModel=vehicleModelCache,
                        Fuel=fuelCache,
                        MISInterval=misIntervalCache.ToString(),
                        FilteredVehicleModel=vehicleFiterCache,
                        //车系描述表，逻辑在后面    
                      
                    };
                })
                .Where(entry => entry != null)  // 去除 null 的项
                .ToList();

            // 将查询结果插入到 DailyServiceReviewFormQueries 表中
            await dbDailyServiceReviewQueryTable.AddRangeAsync(dailyQualityQueryEntries);
            await _dbContext.SaveChangesAsync(); // 保存更改

            _logger.LogInformation($"成功将 {dailyQualityQueryEntries.Count} 条记录插入到 DailyServiceReviewFormQueries 表中。");

            return Ok(new { Message = "数据更新成功", Count = dailyQualityQueryEntries.Count });
        }

        // 计算 MIS 值的辅助方法
        private int CalculateMis(string serviceOrderCreationDate, string? salesDate)
        {
            // 解析日期字符串为 DateTime
            if (DateTime.TryParse(serviceOrderCreationDate, out var serviceOrderDate) &&
                DateTime.TryParse(salesDate, out var salesDateParsed))
            {
                // 计算销售日期与服务单创建日期之间的月数
                var monthDiff = (salesDateParsed.Year - serviceOrderDate.Year) * 12 + salesDateParsed.Month - serviceOrderDate.Month;

                // 向上取整
                var misValue = Math.Ceiling((float)monthDiff / 30); // 30天为一月

                return (int)misValue;  // 返回字符串格式
            }

            return -1; // 如果日期无法解析，则返回 "-1"
        }
    }
}
