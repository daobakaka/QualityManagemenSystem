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

        public class PivotResult
        {
            public string? Order { get; set; }
            public string? ApprovalDate { get; set; }
            public string? VehicleModel { get; set; }
            public string? OldMaterialCode { get; set; }
            public string? OldMaterialDescription { get; set; }
            public string? SupplierShortCode { get; set; }
            public string? ResponsibilitySourceSupplierName { get; set; }
            public string? CaseCount { get; set; }
            public string? CumulativeCaseCount { get; set; }
            public string? MIS3 { get; set; }
            public string? MIS6 { get; set; }
            public string? MIS12 { get; set; }
            public string? MIS24 { get; set; }
            public string? MIS36 { get; set; }
            public string? SMT { get; set; }
            public string? LocationCode { get; set; }
            public string? FaultCode { get; set; }
            public string? BreakPointNum { get; set; }
            public string? BreakPointTime { get; set; }
        }

        [HttpGet("FilterAndPivot")]
        public async Task<IActionResult> FilterAndPivot()
        {

            try
            {
                List<PivotResult> resultsToStore = new List<PivotResult>();
                var duplicateMaterialCodes = new List<PivotResult>();

                IQueryable<DailyServiceReviewFormQuery> query = _context.DailyServiceReviewFormQueries.AsNoTracking()
                    .Where(e => (e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务"))
                    .Where(e => e.ResponsibilitySourceIdentifier == "是")
                    .Where(e => (e.RepairMethod == "更换" || e.RepairMethod == "维修"))
                    .Where(e => e.MaterialType == "物料")
                    .Where(e => e.ApprovalDate == "2024-09-01");
                //|| e.ApprovalDate == "2024-09-02" || e.ApprovalDate == "2024-09-03"

                _logger.LogInformation($"总计数量为：{query.ToList().Count}");

                var vehicleTypes = new List<string>
                {
                    "传统燃油工程",
                    "传统燃油公路",
                    "新能源工程",
                    "新能源公路"
                };

                _logger.LogInformation($"使用固定车型列表，车型数量: {vehicleTypes.Count}");

                var misSteps = new List<int> { 3, 6, 12, 24, 36 };
                var pivotResults = new List<PivotResult>();

                foreach (var vehicle in vehicleTypes)
                {
                    _logger.LogInformation($"开始处理车型: {vehicle}");
                    HashSet<string> collectedMaterialCodes = new HashSet<string>();
                    foreach (var step in misSteps)
                    {
                        _logger.LogInformation($"开始处理MIS步骤: {step}");

                        // 筛选符合当前车型和MIS区间的记录
                        IQueryable<DailyServiceReviewFormQuery> stepDataQuery = query
                            .Where(q => q.FilteredVehicleModel == vehicle &&
                                        (
                                            (step == 3 && (q.MISInterval == "0.0" || q.MISInterval == "3.0")) ||
                                            (step == 6 && (q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0")) ||
                                            (step == 12 && (q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0")) ||
                                            (step == 24 && (q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0")) ||
                                            (step == 36 && (q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0" || q.MISInterval == "36.0"))
                                        ));

                        var stepData = await stepDataQuery.ToListAsync();
                        _logger.LogInformation($"车型: {vehicle}, MIS步骤: {step}, 筛选后记录数: {stepData.Count}");

                        var groupedDataToFilter = stepData
                              .GroupBy(q => q.OldMaterialCode)
                              .Select(g => new
                              {
                                  OldMaterialCode = g.Key,
                                  // 根据当前 step 统计各 MIS 区间数量
                                  MIS3 = step == 3 ? g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0") : 0,
                                  MIS6 = step == 6 ? g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0") : 0,
                                  MIS12 = step == 12 ? g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0") : 0,
                                  MIS24 = step == 24 ? g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0") : 0,
                                  MIS36 = step == 36 ? g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0" || q.MISInterval == "36.0") : 0,

                                  // 使用MIS3cal来计算
                                  MIS3cal = g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0"),
                                  MIS6cal = g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0"),
                                  MIS12cal = g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0"),
                                  MIS24cal = g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0"),
                                  MIS36cal = g.Count(q => q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" || q.MISInterval == "12.0" || q.MISInterval == "24.0" || q.MISInterval == "36.0"),
                              })
                              .ToList();

                        // 过滤分组后的数据
                        var filteredGroupedData = groupedDataToFilter
                                      .Where(g =>
                                      {
                                          switch (step)
                                          {
                                              case 3:
                                                  // 对于传统燃油公路和传统燃油工程，条件为 >= 2，其他车型为 >= 1
                                                  return (vehicle == "传统燃油公路" || vehicle == "传统燃油工程") ? g.MIS3 >= 2 : g.MIS3 >= 1;

                                              case 6:
                                                  // 对于传统燃油公路和传统燃油工程，条件为 >= 3，其他车型为 >= 2
                                                  return (vehicle == "传统燃油公路" || vehicle == "传统燃油工程") ? g.MIS6 >= 3 : g.MIS6 >= 2;

                                              case 12:
                                                  // 对于传统燃油公路和传统燃油工程，条件为 >= 4，其他车型为 >= 3
                                                  return (vehicle == "传统燃油公路" || vehicle == "传统燃油工程") ? g.MIS12 >= 4 : g.MIS12 >= 3;

                                              case 24:
                                                  // 对于 MIS 24 的条件: 
                                                  // 总数 >= 10 且 12MIS < 5 且 24MIS/12MIS >= 1.5
                                                  return g.MIS24cal >= 10 &&
                                                         g.MIS12cal < 5 &&
                                                         g.MIS12cal > 0 && // 防止除零错误
                                                         (g.MIS24cal / (decimal)g.MIS12cal) >= 1.5m; // 使用MIS12cal

                                              case 36:
                                                  // 对于 MIS 36 的条件: 
                                                  // 总数 >= 10 且 12MIS < 5 且 24MIS < 10 且 36MIS/24MIS > 1.5
                                                  return g.MIS36cal >= 20 &&
                                                         g.MIS12cal < 5 &&
                                                         g.MIS24cal < 10 &&
                                                         g.MIS24cal > 0 && // 防止除零错误
                                                         (g.MIS36cal / (decimal)g.MIS24cal) >= 1.5m; // 使用MIS24cal

                                              default:
                                                  return false;
                                          }
                                      })
                                      .ToList();

                        foreach (var item in filteredGroupedData)
                        {

                            collectedMaterialCodes.Add(item?.OldMaterialCode ?? "0");//将物料号加入hash集合
                            var originalData = stepData.FirstOrDefault(q => q.OldMaterialCode == item?.OldMaterialCode);
                            resultsToStore.Add(new PivotResult
                            {
                                OldMaterialCode = item.OldMaterialCode,
                                MIS3 = item.MIS3.ToString(),
                                MIS6 = item.MIS6.ToString(),
                                MIS12 = item.MIS12.ToString(),
                                MIS24 = item.MIS24.ToString(),
                                MIS36 = item.MIS36.ToString(),
                                CaseCount = item.MIS36cal.ToString(),
                                VehicleModel = vehicle, // 当前车辆类型
                                ApprovalDate = originalData?.ApprovalDate, // 从原始数据中填充ApprovalDate
                                OldMaterialDescription = originalData?.OldMaterialDescription, // 从原始数据中填充OldMaterialDescription
                                SupplierShortCode = originalData?.SupplierShortCode, // 从原始数据中填充SupplierShortCode
                                ResponsibilitySourceSupplierName = originalData?.ResponsibilitySourceSupplierName, // 从原始数据中填充ResponsibilitySourceSupplierName
                                CumulativeCaseCount = "NIL", // 从原始数据中填充CumulativeCaseCount
                                SMT = originalData?.LocationCode?.Substring(0, 2) ?? "NIL", // 从原始数据中填充SMTs
                                LocationCode = originalData?.LocationCode, // 从原始数据中填充LocationCode
                                FaultCode = originalData?.FaultCode, // 从原始数据中填充FaultCode
                                BreakPointNum = "0"

                            });
                        }
                        // 确保 resultsToStore 已经被填充
                        if (resultsToStore != null && resultsToStore.Any())
                        {
                            // 使用 LINQ 进行分组和累加
                            var aggregatedResults = resultsToStore
                                .GroupBy(r => r.OldMaterialCode)
                                .Select(g =>
                                {
                                    var first = g.First();

                                    // 累加 MIS 字段
                                    int totalMIS3 = g.Sum(r => int.TryParse(r.MIS3, out var mis3) ? mis3 : 0);
                                    int totalMIS6 = g.Sum(r => int.TryParse(r.MIS6, out var mis6) ? mis6 : 0);
                                    int totalMIS12 = g.Sum(r => int.TryParse(r.MIS12, out var mis12) ? mis12 : 0);
                                    int totalMIS24 = g.Sum(r => int.TryParse(r.MIS24, out var mis24) ? mis24 : 0);
                                    int totalMIS36 = g.Sum(r => int.TryParse(r.MIS36, out var mis36) ? mis36 : 0);

                                    // 更新第一个实例的 MIS 字段
                                    first.MIS3 = totalMIS3.ToString();
                                    first.MIS6 = totalMIS6.ToString();
                                    first.MIS12 = totalMIS12.ToString();
                                    first.MIS24 = totalMIS24.ToString();
                                    first.MIS36 = totalMIS36.ToString();

                                    // 如果需要累加其他字段，如 CaseCount，可以在此处处理
                                    // 例如，累加 CaseCount:
                                    // first.CaseCount = g.Sum(r => int.TryParse(r.CaseCount, out var cc) ? cc : 0).ToString();

                                    return first;//保留第一个实例，其他不符合要求的删除
                                })
                                .ToList();

                            // 替换原始的 resultsToStore
                            resultsToStore = aggregatedResults;
                        }


                    }

                    if (collectedMaterialCodes.Any())
                    {
                        _logger.LogInformation("开始批量计算 MIS36cal");

                        // 执行批量查询，计算每个物料号的 MIS36cal，简化后的代码                

                        var mis36calResults = await query
                 .Where(q => q.FilteredVehicleModel != null && // 确保 FilteredVehicleModel 不为 null
                             q.FilteredVehicleModel == vehicle &&
                              !string.IsNullOrEmpty(q.OldMaterialCode) && 
                              collectedMaterialCodes.Contains(q.OldMaterialCode)&& // 确保 OldMaterialCode 不为 null 或空
                             (q.MISInterval == "0.0" || q.MISInterval == "3.0" || q.MISInterval == "6.0" ||
                              q.MISInterval == "12.0" || q.MISInterval == "24.0" || q.MISInterval == "36.0"))
                 .GroupBy(q => q.OldMaterialCode!)
                 .ToDictionaryAsync(g => g.Key, g => g.Count());


                        _logger.LogInformation("完成批量计算 MIS36cal");

                        // 将计算结果赋值给 resultsToStore 中的 CaseCount
                        foreach (var result in resultsToStore)
                        {
                            if (!string.IsNullOrEmpty(result.OldMaterialCode) &&
                                mis36calResults.TryGetValue(result.OldMaterialCode, out var mis36cal))
                            {
                                result.CaseCount = mis36cal.ToString();
                            }
                          
                        }
                    }

                } 



                //完成后处理断点分散问题


                _logger.LogInformation("+++++++++++++++++++++++++++++++++++++++++初始常规计算已完成" + resultsToStore.Count.ToString());

                    foreach (var result in resultsToStore)
                    {
                        // 打印每个物料号的信息
                        _logger.LogInformation($"物料号: {result.OldMaterialCode}, " +
                                               $"断点时间: {result.BreakPointTime}, " +
                                               $"断点次数: {result.BreakPointNum}, " +
                                               //$"车型: {result.VehicleModel}, " +
                                               //$"审批日期: {result.ApprovalDate}, " +
                                               //$"物料描述: {result.OldMaterialDescription}, " +
                                               //$"供应商短代码: {result.SupplierShortCode}, " +
                                               //$"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                               $"案例数: {result.CaseCount}, " +
                                               $"MIS3: {result.MIS3}, " +
                                               $"MIS6: {result.MIS6}, " +
                                               $"MIS12: {result.MIS12}, " +
                                               $"MIS24: {result.MIS24}, " +
                                               $"MIS36: {result.MIS36}, " +
                                               //$"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                               //$"SMT: {result.SMT}, " +
                                               //$"位置代码: {result.LocationCode}, " +
                                               $"故障代码: {result.FaultCode}");
                    }





                    var breakpoints = await _context.BreakpointAnalysisTables.AsNoTracking().ToListAsync();
                    // 为所有断点时间转换为统一的 YYYY-MM-DD 格式
                    var convertedBreakpoints = breakpoints
                        .Select(b => new
                        {
                            OldMaterialCode = b.MaterialCode,
                            BreakpointTime = b.BreakpointTime ?? "0", // YYMMDD 格式
                            ConvertedDate = DateTime.TryParseExact(b.BreakpointTime, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var startDate)
                                ? startDate.ToString("yyyy-MM-dd")
                                : null
                        })
                        .ToList();



                    foreach (var result in resultsToStore.ToList()) // 使用 ToList() 以避免在遍历中修改集合
                    {
                        // 获取与物料号对应的所有断点
                        var relevantBreakpoints = convertedBreakpoints
                            .Where(b => b.OldMaterialCode == result.OldMaterialCode)
                            .ToList();

                        // 如果有相关的断点，则增加对应的实例
                        if (relevantBreakpoints.Any())
                        {
                            foreach (var breakpoint in relevantBreakpoints)
                            {
                                // 创建新的实例，属性与原始结果相同
                                var newResult = new PivotResult
                                {
                                    Order = result.Order, // 假设 Order 属性需要保留
                                    ApprovalDate = result.ApprovalDate,
                                    VehicleModel = result.VehicleModel,
                                    OldMaterialCode = result.OldMaterialCode,
                                    OldMaterialDescription = result.OldMaterialDescription,
                                    SupplierShortCode = result.SupplierShortCode,
                                    ResponsibilitySourceSupplierName = result.ResponsibilitySourceSupplierName,
                                    CaseCount = result.CaseCount,
                                    CumulativeCaseCount = result.CumulativeCaseCount,
                                    MIS3 = result.MIS3,
                                    MIS6 = result.MIS6,
                                    MIS12 = result.MIS12,
                                    MIS24 = result.MIS24,
                                    MIS36 = result.MIS36,
                                    SMT = result.SMT,
                                    LocationCode = result.LocationCode,
                                    FaultCode = result.FaultCode,
                                    BreakPointNum = (relevantBreakpoints.IndexOf(breakpoint) + 1).ToString(), // 断点编号从1开始
                                    BreakPointTime = breakpoint.ConvertedDate,
                                };

                                // 添加新的实例到结果列表中
                                resultsToStore.Add(newResult);
                            }
                        }
                    }

                
                        // 假设 duplicateMaterialCodes 已经初始化
                        _logger.LogInformation("+++++++++++++++++++++++++++++++++++++++++添加断点重复项已经完毕" + resultsToStore.Count.ToString());
                        var seenMaterialCodes = new HashSet<string>(); // 用于跟踪已经添加的物料号

                        foreach (var duplicate in resultsToStore.ToList()) // 使用 ToList() 避免在遍历时修改集合
                        {
                            // 查找所有与当前 duplicate.OldMaterialCode 相同的物料号
                            var duplicates = resultsToStore.Where(r => r.OldMaterialCode == duplicate.OldMaterialCode).ToList();

                            // 如果存在重复项并且该物料号尚未被添加过
                            if (duplicates.Count > 1 && !seenMaterialCodes.Contains(duplicate.OldMaterialCode))
                            {
                                duplicateMaterialCodes.AddRange(duplicates);
                                seenMaterialCodes.Add(duplicate.OldMaterialCode); // 标记为已添加
                            }

                            // 从 resultsToStore 中移除这些重复项

                        }
                        resultsToStore.RemoveAll(r => seenMaterialCodes.Contains(r.OldMaterialCode));
                        _logger.LogInformation("+++++++++++++++++++++++++++++++++++++++++++重复断点列表已经生成" + duplicateMaterialCodes.Count.ToString());
                        _logger.LogInformation("+++++++++++++++++++++++++++++++++++++++++++剩余不需要进行断点处理的列表" + resultsToStore.Count.ToString());




                        // 假设 duplicateMaterialCodes 已经被正确填充
                        foreach (var result in duplicateMaterialCodes)
                        {
                            // 获取与物料号对应的所有断点
                            var relevantBreakpoints = convertedBreakpoints
                                .Where(b => b.OldMaterialCode == result.OldMaterialCode)
                                .ToList();
                            //这是储存的每个物料号的断点的数量，至少应该是两个
                            if (relevantBreakpoints.Any())
                            {

                                int mis3, mis6, mis12, mis24, mis36;
                                mis3 = mis6 = mis12 = mis24 = mis36 = 0;
                                foreach (var queryItem in query)//用手写6次断点几乎涵盖所有情况，每次遍历物料号就可以写入下面 BreakPointNum对应的值进入duplicateMaterialCodes表
                                {
                                    string manufactureMonth = queryItem.ManufacturingMonth ?? "0";
                                    if (relevantBreakpoints.Count == 2)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        // string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";

                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else  //断点时间小于制造月，断点之后产品，断点失效
                                        {
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }
                                            }


                                        }


                                    }
                                    else if(relevantBreakpoints.Count == 3)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";
                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else if (result.BreakPointNum == "2")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else
                                        {
                                            if (startDateStr2.CompareTo(manufactureMonth) < 0 )
                                            {
                                                //2次断点时间小于制造月，2次断点失效产品
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }

                                    }
                                    else if (relevantBreakpoints.Count == 4)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";
                                        string startDateStr3 = relevantBreakpoints[3].ConvertedDate ?? "0";
                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else if (result.BreakPointNum == "2")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "3")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else
                                        {
                                            if (startDateStr3.CompareTo(manufactureMonth) < 0)
                                            {
                                                //2次断点时间小于制造月，2次断点失效产品
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }

                                    }
                                    else if (relevantBreakpoints.Count == 5)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";
                                        string startDateStr3 = relevantBreakpoints[3].ConvertedDate ?? "0";
                                        string startDateStr4 = relevantBreakpoints[4].ConvertedDate ?? "0"; 
                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else if (result.BreakPointNum == "2")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "3")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "4")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr3.CompareTo(manufactureMonth) < 0 && startDateStr4.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else
                                        {
                                            if (startDateStr4.CompareTo(manufactureMonth) < 0)
                                            {
                                                //2次断点时间小于制造月，2次断点失效产品
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }

                                    }
                                    else if (relevantBreakpoints.Count == 6)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";
                                        string startDateStr3 = relevantBreakpoints[3].ConvertedDate ?? "0";
                                        string startDateStr4 = relevantBreakpoints[4].ConvertedDate ?? "0";
                                        string startDateStr5 = relevantBreakpoints[5].ConvertedDate ?? "0";
                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else if (result.BreakPointNum == "2")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "3")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "4")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr3.CompareTo(manufactureMonth) < 0 && startDateStr4.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "5")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr4.CompareTo(manufactureMonth) < 0 && startDateStr5.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else
                                        {
                                            if (startDateStr5.CompareTo(manufactureMonth) < 0)
                                            {
                                                //2次断点时间小于制造月，2次断点失效产品
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }

                                    }
                                    else if (relevantBreakpoints.Count == 7)
                                    {
                                        string startDateStr1 = relevantBreakpoints[1].ConvertedDate ?? "0";
                                        string startDateStr2 = relevantBreakpoints[2].ConvertedDate ?? "0";
                                        string startDateStr3 = relevantBreakpoints[3].ConvertedDate ?? "0";
                                        string startDateStr4 = relevantBreakpoints[4].ConvertedDate ?? "0";
                                        string startDateStr5 = relevantBreakpoints[5].ConvertedDate ?? "0";
                                        string startDateStr6 = relevantBreakpoints[6].ConvertedDate ?? "0";
                                        if (result.BreakPointNum == "1")
                                        {

                                            //断点时间大于等于制造月,断点前产品
                                            if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }
                                        else if (result.BreakPointNum == "2")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                            if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "3")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于2次断点到3次断点间的产品
                                            if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "4")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于3次断点到4次断点间的产品
                                            if (startDateStr3.CompareTo(manufactureMonth) < 0 && startDateStr4.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "5")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于4次断点到5次断点间的产品
                                            if (startDateStr4.CompareTo(manufactureMonth) < 0 && startDateStr5.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else if (result.BreakPointNum == "6")
                                        {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于5次断点到6次断点间的产品
                                            if (startDateStr5.CompareTo(manufactureMonth) < 0 && startDateStr6.CompareTo(manufactureMonth) >= 0)
                                            {
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }
                                        }
                                        else
                                        {
                                            if (startDateStr6.CompareTo(manufactureMonth) < 0)
                                            {
                                                //2次断点时间小于制造月，2次断点失效产品
                                                if (result.MIS3 != "0") { mis3++; result.MIS3 = mis3.ToString(); }
                                                else if (result.MIS6 != "0") { mis6++; result.MIS6 = mis6.ToString(); }
                                                else if (result.MIS12 != "0") { mis12++; result.MIS12 = mis12.ToString(); }
                                                else if (result.MIS24 != "0") { mis24++; result.MIS24 = mis24.ToString(); }
                                                else if (result.MIS36 != "0") { mis36++; result.MIS36 = mis36.ToString(); }

                                            }

                                        }

                                    }
                                }

                                // 例如将这些值存储到 result 中或进行其他逻辑处理
                            }
                        }

                        foreach (var item in duplicateMaterialCodes.ToList())
                        {

                            resultsToStore.Add(item);
                        }
                        _logger.LogInformation("+++++++++++++++++++++++++++++++++++++++++++经过处理的重复断点列表已加入到最终结果中" + resultsToStore.Count.ToString());




                        // 整理最终结果，按 OldMaterialCode 分组，汇总 CaseCount 和 MISValues，并分配自然排序 Order
                        _logger.LogInformation("开始打印最终的结果+++++++++++++++++++++++++++++++++++");
                        foreach (var result in resultsToStore)
                        {
                            // 打印每个物料号的信息
                            _logger.LogInformation($"物料号: {result.OldMaterialCode}, " +
                                                   $"断点时间: {result.BreakPointTime}, " +
                                                   $"断点次数: {result.BreakPointNum}, " +
                                                   $"车型: {result.VehicleModel}, " +
                                                   $"审批日期: {result.ApprovalDate}, " +
                                                   $"物料描述: {result.OldMaterialDescription}, " +
                                                   $"供应商短代码: {result.SupplierShortCode}, " +
                                                   $"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                                   $"案例数: {result.CaseCount}, " +
                                                   $"MIS3: {result.MIS3}, " +
                                                   $"MIS6: {result.MIS6}, " +
                                                   $"MIS12: {result.MIS12}, " +
                                                   $"MIS24: {result.MIS24}, " +
                                                   $"MIS36: {result.MIS36}, " +
                                                   $"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                                   $"SMT: {result.SMT}, " +
                                                   $"位置代码: {result.LocationCode}, " +
                                                   $"故障代码: {result.FaultCode}");
                        }

                        return Ok(1);
                    }



                
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering and pivoting data.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
