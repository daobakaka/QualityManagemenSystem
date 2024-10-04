using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinMVC.Data;
using WebWinMVC.Models;

namespace WebWinMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomaticDataCalculationController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;
        private readonly ILogger<AutomaticDataCalculationController> _logger;

        public AutomaticDataCalculationController(ILogger<AutomaticDataCalculationController> logger, JRZLWTDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // 定义一个内部DTO类来存储透视结果，所有属性均为字符串
        public class PivotResult
        {
            public string ?OldMaterialCode { get; set; }
            public string ?ServiceOrderCount { get; set; }
            public string ?MISValue { get; set; }
            public string ?VehicleType { get; set; }
        }

        /// <summary>
        /// 筛选并透视DailyServiceReviewFormQuery数据
        /// </summary>
        /// <returns>透视结果列表</returns>
        [HttpGet("FilterAndPivot")]
        public async Task<IActionResult> FilterAndPivot()
        {
            try
            {
                // 初始化查询，使用AsNoTracking提高查询性能
                IQueryable<DailyServiceReviewFormQuery> query = _context.DailyServiceReviewFormQueries.AsNoTracking()
                    .Where(q => q.ResponsibilitySourceIdentifier == "是");

                // 获取所有筛选车型
                var vehicleTypes = await query
                    .Select(q => q.FilteredVehicleModel)
                    .Distinct()
                    .ToListAsync();

                // 定义MIS区间的步骤
                var misSteps = new List<int> { 3, 6, 12, 24, 36 };

                // 初始化结果列表
                var pivotResults = new List<PivotResult>();

                foreach (var vehicle in vehicleTypes)
                {
                    if (string.IsNullOrEmpty(vehicle))
                    {
                        continue; // 跳过空的车型
                    }

                    foreach (var step in misSteps)
                    {
                        IQueryable<DailyServiceReviewFormQuery> stepQuery = null;

                        switch (step)
                        {
                            case 3:
                                // MIS区间为 "0" 或 "3"
                                stepQuery = query.Where(q =>
                                    (q.MISInterval == "0" || q.MISInterval == "3") &&
                                    q.FilteredVehicleModel == vehicle);
                                break;
                            case 6:
                                // MIS区间为 "0", "3", "6"
                                stepQuery = query.Where(q =>
                                    (q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6") &&
                                    q.FilteredVehicleModel == vehicle);
                                break;
                            case 12:
                                // MIS区间为 "0", "3", "6", "12"
                                stepQuery = query.Where(q =>
                                    (q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12") &&
                                    q.FilteredVehicleModel == vehicle);
                                break;
                            case 24:
                                // MIS区间为 "0", "3", "6", "12", "24"
                                stepQuery = query.Where(q =>
                                    (q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24") &&
                                    q.FilteredVehicleModel == vehicle);
                                break;
                            case 36:
                                // MIS区间为 "0", "3", "6", "12", "24", "36"
                                stepQuery = query.Where(q =>
                                    (q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24" || q.MISInterval == "36") &&
                                    q.FilteredVehicleModel == vehicle);
                                break;
                            default:
                                stepQuery = Enumerable.Empty<DailyServiceReviewFormQuery>().AsQueryable();
                                break;
                        }

                        // 根据当前MIS步骤进行数据处理
                        switch (step)
                        {
                            case 3:
                                // 第一步: 筛选MIS区间为“0”和“3”，计数ServiceOrder >= 2
                                var step1Group = await stepQuery
                                     .Where(q => Convert.ToInt32(q.MISInterval) >= 2)
                                    .GroupBy(q => q.OldMaterialCode)
                                    .Select(g => new PivotResult
                                    {
                                        OldMaterialCode = g.Key,
                                        ServiceOrderCount = g.Select(q => q.ServiceOrder).Distinct().Count().ToString(),
                                        MISValue = "3",
                                        VehicleType = vehicle
                                    })
                                   
                                    .ToListAsync();

                                pivotResults.AddRange(step1Group);
                                _logger.LogInformation($"完成3MIS筛选，车型: {vehicle}");
                                break;

                            case 6:
                                // 第二步: 扩展MIS区间到“0”, “3”, “6”，筛选MIS >=3
                                var step2Group = await stepQuery
                                    .Where(q => Convert.ToInt32(q.MISInterval) >= 3)
                                    .GroupBy(q => q.OldMaterialCode)
                                    .Select(g => new PivotResult
                                    {
                                        OldMaterialCode = g.Key,
                                        ServiceOrderCount = g.Select(q => q.ServiceOrder).Distinct().Count().ToString(),
                                        MISValue = "6",
                                        VehicleType = vehicle
                                    })
                                    .ToListAsync();

                                pivotResults.AddRange(step2Group);
                                _logger.LogInformation($"完成6MIS筛选，车型: {vehicle}");
                                break;

                            case 12:
                                // 第三步: 扩展MIS区间到“0”, “3”, “6”, “12”，筛选MIS >=4
                                var step3Group = await stepQuery
                                    .Where(q => Convert.ToInt32(q.MISInterval) >= 4)
                                    .GroupBy(q => q.OldMaterialCode)
                                    .Select(g => new PivotResult
                                    {
                                        OldMaterialCode = g.Key,
                                        ServiceOrderCount = g.Select(q => q.ServiceOrder).Distinct().Count().ToString(),
                                        MISValue = "12",
                                        VehicleType = vehicle
                                    })
                                    .ToListAsync();

                                foreach (var item in step3Group)
                                {
                                    var existing = pivotResults.FirstOrDefault(r => r.OldMaterialCode == item.OldMaterialCode);
                                    if (existing == null)
                                    {
                                        pivotResults.Add(item);
                                    }
                                    else
                                    {
                                        // 计算现有的MIS值总和
                                        if (decimal.TryParse(existing.MISValue, out decimal sumMIS))
                                        {
                                            if (sumMIS < 5 && ((12 - sumMIS) / sumMIS) >= 1.5m)
                                            {
                                                pivotResults.Add(item);
                                            }
                                        }
                                    }
                                }

                                _logger.LogInformation($"完成12MIS筛选，车型: {vehicle}");
                                break;

                            case 24:
                                // 第四步: 扩展MIS区间到“0”, “3”, “6”, “12”, “24”，筛选MIS >=10
                                var step4Group = await stepQuery
                                    .Where(q => Convert.ToInt32(q.MISInterval) >= 10)
                                    .GroupBy(q => q.OldMaterialCode)
                                    .Select(g => new PivotResult
                                    {
                                        OldMaterialCode = g.Key,
                                        ServiceOrderCount = g.Select(q => q.ServiceOrder).Distinct().Count().ToString(),
                                        MISValue = "24",
                                        VehicleType = vehicle
                                    })
                                    .ToListAsync();

                                foreach (var item in step4Group)
                                {
                                    var existing = pivotResults.FirstOrDefault(r => r.OldMaterialCode == item.OldMaterialCode);
                                    if (existing == null)
                                    {
                                        pivotResults.Add(item);
                                    }
                                    else
                                    {
                                        // 计算现有的MIS值总和（针对MIS=10,11,12）
                                        var sumTarget = pivotResults
                                            .Where(r => r.OldMaterialCode == item.OldMaterialCode &&
                                                        (r.MISValue == "10" || r.MISValue == "11" || r.MISValue == "12"))
                                            .Sum(r =>
                                            {
                                                return decimal.TryParse(r.MISValue, out decimal misValSum) ? misValSum : 0;
                                            });

                                        // 条件判断: sumTarget < 10 && (24 - sumTarget) / sumTarget >= 1.5
                                        if (sumTarget < 10 && sumTarget > 0)
                                        {
                                            if (decimal.TryParse(item.MISValue, out decimal misValItem))
                                            {
                                                decimal ratio = (misValItem - sumTarget) / sumTarget;
                                                if (ratio >= 1.5m)
                                                {
                                                    pivotResults.Add(item);
                                                }
                                            }
                                        }
                                    }
                                }

                                _logger.LogInformation($"完成24MIS筛选，车型: {vehicle}");
                                break;

                            case 36:
                                // 第五步: 扩展MIS区间到“0”, “3”, “6”, “12”, “24”, “36”，筛选MIS >=20
                                var step5Group = await stepQuery
                                    .Where(q => Convert.ToInt32(q.MISInterval) >= 20)
                                    .GroupBy(q => q.OldMaterialCode)
                                    .Select(g => new PivotResult
                                    {
                                        OldMaterialCode = g.Key,
                                        ServiceOrderCount = g.Select(q => q.ServiceOrder).Distinct().Count().ToString(),
                                        MISValue = "36",
                                        VehicleType = vehicle
                                    })
                                    .ToListAsync();

                                foreach (var item in step5Group)
                                {
                                    var existing = pivotResults.FirstOrDefault(r => r.OldMaterialCode == item.OldMaterialCode);
                                    if (existing == null)
                                    {
                                        pivotResults.Add(item);
                                    }
                                    else
                                    {
                                        // 计算现有的MIS值总和（针对MIS=10,11,12,13）
                                        var sumTarget = pivotResults
                                            .Where(r => r.OldMaterialCode == item.OldMaterialCode &&
                                                        (r.MISValue == "10" || r.MISValue == "11" ||
                                                         r.MISValue == "12" || r.MISValue == "13"))
                                            .Sum(r =>
                                            {
                                                return decimal.TryParse(r.MISValue, out decimal misValSum) ? misValSum : 0;
                                            });

                                        // 条件判断: sumTarget < 10 && (36 - sumTarget) / sumTarget >= 1.5
                                        if (sumTarget < 10 && sumTarget > 0)
                                        {
                                            if (decimal.TryParse(item.MISValue, out decimal misValItem))
                                            {
                                                decimal ratio = (misValItem - sumTarget) / sumTarget;
                                                if (ratio >= 1.5m)
                                                {
                                                    pivotResults.Add(item);
                                                }
                                            }
                                        }
                                    }
                                }

                                _logger.LogInformation($"完成36MIS筛选，车型: {vehicle}");
                                break;
                        }
                    }
                }

                // 整理最终结果，去除重复的OldMaterialCode，并汇总ServiceOrderCount和MISValues
                var finalResults = pivotResults
                    .GroupBy(r => r.OldMaterialCode)
                    .Select(g => new
                    {
                        OldMaterialCode = g.Key,
                        ServiceOrderCount = g.Sum(x =>
                            int.TryParse(x.ServiceOrderCount, out int count) ? count : 0
                        ).ToString(),
                        MISValues = g.Select(x => x.MISValue).Distinct().OrderBy(x => x).ToList(),
                        VehicleType = g.First().VehicleType
                    })
                    .Where(r => int.TryParse(r.ServiceOrderCount, out int finalCount) && finalCount >= 2)
                    .ToList();

                return Ok(finalResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering and pivoting data.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
