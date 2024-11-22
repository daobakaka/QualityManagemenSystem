using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AutomaticDataChangeController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;
        private readonly ILogger<AutomaticDataChangeController> _logger;


        public AutomaticDataChangeController(ILogger<AutomaticDataChangeController> logger, JRZLWTDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        private string SubtractMonths(string dateStr, int months)
        {
            var parts = dateStr.Split('-');
            if (parts.Length != 2) // 调整为检查长度为2
                return dateStr; // 无效格式

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);

            month -= months;
            while (month <= 0)
            {
                month += 12;
                year -= 1;
            }

            string adjustedMonth = month < 10 ? $"0{month}" : month.ToString();
            return $"{year}-{adjustedMonth}"; // 只返回年份和月份
        }


        private void AdditionalConsole(string ApprovalDate,string FilterDay,string startDateStr,string endDateStr,string filterDay)
        {

            _logger.LogError($"输入审核日期:{ApprovalDate};处理后开始日期：{startDateStr};处理后结束日期{endDateStr}" +
                             $"输入筛选日期：{FilterDay};处理后的筛选日期，筛选月:{filterDay};经sub方法处理后的筛选月:{SubtractMonths("2024-05", 6)}");


        }
        [HttpPost("FilterAndPivot")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> FilterAndPivot([FromForm] string ApprovalDate, [FromForm] string FilterDay, [FromForm] int MFmonth = 0, [FromForm] int MonthOffset = 0)
        { 
            try
            {
                List<PivotResult> resultsToStore = new List<PivotResult>();
                var resultToStoreQuery = new List<PivotResult>();
                var duplicateMaterialCodes = new List<PivotResult>();//用于添加重复条件均满足的相关参数
                var resultToStoreEditAndQuery=new List<PivotResult>();//用于对处理之后的表进行编辑或查询
                var seenMaterialCodes = new HashSet<string>(); // 用于跟踪已经添加的物料号，筛选车型，供应商编号
                string? startDateStr = null;
                string? endDateStr = null;//ins the date time that is different of the Caluculating class
                string? filterDay = null;//ins the string to cache the FilterDay sting

                IQueryable<DailyServiceReviewFormQuery> query = _context.DailyServiceReviewFormQueries.AsNoTracking()
                    .Where(e => (e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务"))
                    .Where(e => e.ResponsibilitySourceIdentifier == "是")
                    .Where(e => (e.RepairMethod == "更换" || e.RepairMethod == "维修"))
                    .Where(e => e.MaterialType == "物料");


                _logger.LogError($"当前数量: {query.Count()}");
                // 处理 ApprovalDate 参数
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


                if (!string.IsNullOrEmpty(FilterDay))
                {
                    Console.WriteLine("----这里没有问题");
                    // 解析 "yyMMdd" 格式的日期
                    if (DateTime.TryParseExact(FilterDay, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out var changeday))
                    {
                        // 减去 MonthOffset 月
                        
                        DateTime otherDay = changeday.AddMonths(-MonthOffset);
                      
                        // 转换为 "yyyy-MM" 格式
                        filterDay = otherDay.ToString("yyyy-MM");
                        Console.WriteLine("-----originalday:" + FilterDay + "+++++++++++++++++++Chnageday:" + changeday+"!!!!finalyday:"+filterDay);
                    }
                    else
                    {
                        _logger.LogWarning($"无法解析的日期格式: {filterDay}");
                        return BadRequest(new { Message = $"无法解析的日期格式: {filterDay}" });
                    }
                }

             

                _logger.LogError($"输入审核日期:{ApprovalDate};处理后开始日期：{startDateStr};处理后结束日期{endDateStr}" +
                                 $"输入筛选日期：{FilterDay};处理后的筛选日期，筛选月:{filterDay};经sub方法处理后的筛选月3mis:{SubtractMonths(filterDay,6)}" +
                                 $"经sub方法处理后的筛选月6mis:{SubtractMonths(filterDay,9)};经sub方法处理后的筛选月12mis:{SubtractMonths(filterDay,15)}" +
                                 $"经sub方法处理后的筛选月24mis:{SubtractMonths(filterDay,25)};经sub方法处理后的筛选月48mis:{SubtractMonths(filterDay,51)}");

                int initialCount = await query.CountAsync();
                _logger.LogError($"初始筛选数量为：{initialCount}");
                    var misSteps = new List<int> { 3, 6, 12, 24, 48 };
                    HashSet<string> collectedMaterialCodes = new HashSet<string>();
                    resultsToStore.Clear();//每次筛选不同车型的时候先清空内容
                                           // 筛选符合当前车型和MIS区间的记录,去除车型和步骤的单独筛选，累计到一起进行筛选，这里筛选制造月完全可以简化逻辑，现在这个表是就是符合要求的表
                IQueryable<DailyServiceReviewFormQuery> stepDataQuery = query
                                                        .Where(q =>
                                                        (
                                                        ((q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "-1") &&
                                                         q.ManufacturingMonth.CompareTo(SubtractMonths(filterDay, 6 + 6 + MFmonth)) >= 0 &&
                                                         q.ManufacturingMonth.CompareTo(filterDay) <= 0) ||

                                                        ((q.MISInterval == "6") &&
                                                         q.ManufacturingMonth.CompareTo(SubtractMonths(filterDay, 9 + 6 + MFmonth)) >= 0 &&
                                                         q.ManufacturingMonth.CompareTo(filterDay) <= 0) ||

                                                        ((q.MISInterval == "12") &&
                                                         q.ManufacturingMonth.CompareTo(SubtractMonths(filterDay, 15 + 6 + MFmonth)) >= 0 &&
                                                         q.ManufacturingMonth.CompareTo(filterDay) <= 0) ||

                                                        ((q.MISInterval == "24") &&
                                                         q.ManufacturingMonth.CompareTo(SubtractMonths(filterDay, 27 + 6 + MFmonth)) >= 0 &&
                                                         q.ManufacturingMonth.CompareTo(filterDay) <= 0) ||

                                                        ((q.MISInterval == "36" || q.MISInterval == "48") &&
                                                         q.ManufacturingMonth.CompareTo(SubtractMonths(filterDay, 51 + 6 + MFmonth)) >= 0 &&
                                                         q.ManufacturingMonth.CompareTo(filterDay) <= 0)
                                                        ));

                var stepData = await stepDataQuery.ToListAsync();
                        _logger.LogError($"----筛选后记录数: {stepData.Count}");

                        //foreach (var item in stepData)
                        //{
                        //    _logger.LogError($"mis--:{item.MIS},misInterval--:{item.MISInterval},vechelType--:{item.FilteredVehicleModel},MF--:{item.ManufacturingMonth}");


                        //}

                        foreach (var step in misSteps)//这里重新按照分离之后的表进行筛选，(逻辑改为只要符合一次要求，就纳入HASH 表，每次分别判断，最终统一统计)
                        {
                            //这里的筛选数量是正确的，制造月的引入已完成，这里同时还可以引入车型！！！--------------
                            var groupedDataToFilter = stepData
                                  .GroupBy(q => new { q.OldMaterialCode, q.SupplierShortCode, q.FilteredVehicleModel })
                                  .Select(g => new
                                  {
                                      OldMaterialCode = g.Key.OldMaterialCode,
                                      SupplierShortCode = g.Key.SupplierShortCode,
                                      FilteredVehicleModel = g.Key.FilteredVehicleModel,
                                      // 根据当前 step 统计各 MIS 区间数量
                                      MIS3 = step == 3 ? g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "-1") : 0,
                                      MIS6 = step == 6 ? g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "-1") : 0,
                                      MIS12 = step == 12 ? g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "-1") : 0,
                                      MIS24 = step == 24 ? g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24" || q.MISInterval == "-1") : 0,
                                      MIS48 = step == 48 ? g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24" || q.MISInterval == "36" || q.MISInterval == "48" || q.MISInterval == "-1") : 0,

                                      // 使用MIS3cal来计算
                                      MIS3cal = g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "-1"),
                                      MIS6cal = g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "-1"),
                                      MIS12cal = g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "-1"),
                                      MIS24cal = g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24" || q.MISInterval == "-1"),
                                      MIS48cal = g.Count(q => q.MISInterval == "0" || q.MISInterval == "3" || q.MISInterval == "6" || q.MISInterval == "12" || q.MISInterval == "24" || q.MISInterval == "36" || q.MISInterval == "48" || q.MISInterval == "-1"),
                                  })
                                  .ToList();


                            // 过滤分组后的数据, 现在增加了供应商的筛选条件，这里判断MIS数的筛选逻辑，filterdGroupData 这个储存所有符合规则的数据
                            var filteredGroupedData = groupedDataToFilter
                                          .Where(g =>
                                          {
                                              switch (step)
                                              {
                                                  case 3:
                                                      // 对于传统燃油公路和传统燃油工程，条件为 >= 2，其他车型为 >= 1
                                                      return (g.FilteredVehicleModel == "传统燃油公路" || g.FilteredVehicleModel == "传统燃油工程") ? g.MIS3 >= 2 : g.MIS3 >= 1;

                                                  case 6:
                                                      
                                                      // 对于传统燃油公路和传统燃油工程，条件为 >= 3，其他车型为 >= 2
                                                      return (g.FilteredVehicleModel == "传统燃油公路" || g.FilteredVehicleModel == "传统燃油工程") ? g.MIS6 >= 3 : g.MIS6 >= 2;

                                                  case 12:
                                                      // 对于传统燃油公路和传统燃油工程，条件为 >= 4，其他车型为 >= 3
                                                      return (g.FilteredVehicleModel == "传统燃油公路" || g.FilteredVehicleModel == "传统燃油工程") ? g.MIS12 >= 4 : g.MIS12 >= 3;

                                                  case 24:
                                                      // 对于 MIS 24 的条件: 
                                                      // 总数 >= 10 且 12MIS < 5 且 24MIS/12MIS >= 1.5
                                                      return g.MIS24cal >= 10 &&
                                                             g.MIS12cal < 5 &&
                                                             g.MIS12cal > 0 && // 防止除零错误
                                                             (g.MIS24cal / (decimal)g.MIS12cal) >= 1.5m; // 使用MIS12cal

                                                  case 48:
                                                      // 对于 MIS 48 的条件: 
                                                      // 总数 >= 10 且 12MIS < 5 且 24MIS < 10 且 48MIS/24MIS > 1.5
                                                      return g.MIS48cal >= 20 &&
                                                             g.MIS12cal < 5 &&
                                                             g.MIS24cal < 10 &&
                                                             g.MIS24cal > 0 && // 防止除零错误
                                                             (g.MIS48cal / (decimal)g.MIS24cal) >= 1.5m; // 使用MIS24cal

                                                  default:
                                                      return false;
                                              }
                                          })
                                          .ToList();

                    //find:现在的逻辑变了，仅识别出一个问题之后，就可以计算累计，并且随后的筛选中永久去除物料号，这里直接执行累加--！！！
                    foreach (var item in filteredGroupedData)//构建临时的内存表，这里增加供应商筛选的逻辑,同时增加车型筛选的逻辑---！！，创建一个临时表
                    {
                        // 创建一个唯一的标识字符串，由物料号和供应商短代码组成
                        string uniqueKey = $"{item.OldMaterialCode}-{item?.SupplierShortCode}-{item?.FilteredVehicleModel}";

                        // 将物料号和供应商短代码的组合加入到哈希集合
                        if (collectedMaterialCodes.Add(uniqueKey)) // 将组合字符串加入hash集合,如果数据有重复，则HASH SET 自动排除，所以留下的都是唯一值
                        {
                            var originalData = stepData.FirstOrDefault(q => q.OldMaterialCode == item.OldMaterialCode &&
                                                                            q.SupplierShortCode == item.SupplierShortCode &&
                                                                            q.FilteredVehicleModel == item.FilteredVehicleModel);
                            resultsToStore.Add(new PivotResult
                            {
                                OldMaterialCode = item.OldMaterialCode,
                                SupplierShortCode = item.SupplierShortCode,
                                FilteredVehicleModel = item.FilteredVehicleModel,
                                IssueAttributes=FilterDay.ToString()+"**"+MFmonth.ToString()+"**"+MonthOffset+"**"+ ApprovalDate,//筛选范围+筛选日期+制造月缩放范围+日期偏移

                                //---Store,里面添加相应的车型
                                MIS3 = item.MIS3cal.ToString(),
                                MIS6 = item.MIS6cal.ToString(),
                                MIS12 = item.MIS12cal.ToString(),
                                MIS24 = item.MIS24cal.ToString(),
                                MIS48 = item.MIS48cal.ToString(),
                                CaseCount = item.MIS48cal.ToString(),
                                VehicleModel = item?.FilteredVehicleModel.ToString(), // 当前车辆类型
                                                                                      //--后面的数据都是从原始数据中填充
                                ApprovalDate = originalData?.ApprovalDate, // 从原始数据中填充ApprovalDate
                                OldMaterialDescription = originalData?.OldMaterialDescription, // 从原始数据中填充OldMaterialDescription
                                ResponsibilitySourceSupplierName = originalData?.ResponsibilitySourceSupplierName, // 从原始数据中填充ResponsibilitySourceSupplierName
                                CumulativeCaseCount = "NIL", // 从原始数据中填充CumulativeCaseCount
                                SMT = originalData?.LocationCode?.Substring(0, 2) ?? "NIL", // 从原始数据中填充SMTs
                                LocationCode = originalData?.LocationCode, // 从原始数据中填充LocationCode
                                FaultCode = originalData?.FaultCode, // 从原始数据中填充FaultCode
                                BreakPointNum = "0",
                                BreakPointTime = "NQI",
                            });//
                             }
                        }
                     }
                // 确保 resultsToStore 已经被填充，执行累加逻辑,更改了逻辑，所以之前的累加已经不必要了，这里直接删除if(resultsToStore != null && resultsToStore.Any())
                //collectedMaterialCodes.Any())  同样的这一段逻辑也不需要了               
                //执行查询储存表逻辑,创建一个临时表
                //-------------------------------------------------------------------------车型单次筛选完成
                foreach (var result in resultsToStore)
                {
                   
                    
                    // 打印每个物料号的信息
                    Console.WriteLine($"物料号: {result.OldMaterialCode}, " +
                                           $"断点时间: {result.BreakPointTime}, " +
                                           $"断点次数: {result.BreakPointNum}, " +
                                           $"车型: {result.VehicleModel}, " +
                                           //$"审批日期: {result.ApprovalDate}, " +
                                           //$"物料描述: {result.OldMaterialDescription}, " +
                                           $"供应商短代码: {result.SupplierShortCode}, " +
                                           $"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                           $"问题属性: {result.IssueAttributes}, "+
                                           $"案例数: {result.CaseCount}, " +
                                           $"MIS3: {result.MIS3}, " +
                                           $"MIS6: {result.MIS6}, " +
                                           $"MIS12: {result.MIS12}, " +
                                           $"MIS24: {result.MIS24}, " +
                                           $"MIS48: {result.MIS48}, " +
                                           //$"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                           //$"SMT: {result.SMT}, " +
                                           //$"位置代码: {result.LocationCode}, " +
                                           $"故障代码: {result.FaultCode}");
                   
                }
                //------------------------------------完成后处理断点分散问题 ---------
                _logger.LogError("+++++++++++++++++++++++++++++++++++++++++初始常规计算已完成，开始计算断点,筛选数量" + resultsToStore.Count.ToString());

                var breakpoints = await _context.BreakpointAnalysisTables.AsNoTracking().ToListAsync();
                // 为所有断点时间转换为统一的 YYYY-MM-DD 格式,这里已经在上传的过程中转换过格式了，所以现在不需要了,提取的表需要保留,增加分析表按时间排序
                var convertedBreakpoints = breakpoints
                    .Select(b => new
                    {
                        OldMaterialCode = b.MaterialCode,
                        BreakpointTime = b.BreakpointTime ?? "0", // YYMMDD 格式
                        FilteredVehicleModel = b.FilteredVehicleModel,
                        SupplierShortCode = b.SupplierShortCode,
                    })
                    .OrderBy(bp=>bp.BreakpointTime).ToList();
                //---
                //foreach (var item in convertedBreakpoints)
                //{


                //    _logger.LogInformation($"断点信息 - 物料号: {item.OldMaterialCode}, 断点时间: {item.BreakpointTime}, 车型: {item.FilteredVehicleModel}, 供应商短代码: {item.SupplierShortCode}");

                //}

                foreach (var result in resultsToStore.ToList()) // 使用 ToList() 以避免在遍历中修改集合
                {
                    // 获取与物料号对应的所有断点
                    var relevantBreakpoints = convertedBreakpoints
                        .Where(b => b.OldMaterialCode == result.OldMaterialCode&&
                                    b.FilteredVehicleModel==result.FilteredVehicleModel&&
                                    b.SupplierShortCode == result.SupplierShortCode)
                        .ToList();
                    //Console.WriteLine($"每个单例在断点表中出现的次数:{relevantBreakpoints.Count},当前项目的值{result.OldMaterialCode}-{result.FilteredVehicleModel}-{result.SupplierShortCode}" +
                    //    $"当前筛选项目");
                    // 如果有相关的断点，则增加对应的实例
                    if (relevantBreakpoints.Any())
                    {
                        var newZeroBreakpointResult = new PivotResult
                        {
                            Order = result.Order, // 假设 Order 属性需要保留
                            ApprovalDate = result.ApprovalDate,
                            VehicleModel = result.VehicleModel,
                            OldMaterialCode = result.OldMaterialCode,
                            OldMaterialDescription = result.OldMaterialDescription,
                            SupplierShortCode = result.SupplierShortCode,
                            ResponsibilitySourceSupplierName = result.ResponsibilitySourceSupplierName,
                            IssueAttributes = result.IssueAttributes,
                            CaseCount = result.CaseCount,
                            CumulativeCaseCount = result.CumulativeCaseCount,
                            MIS3 = result.MIS3,
                            MIS6 = result.MIS6,
                            MIS12 = result.MIS12,
                            MIS24 = result.MIS24,
                            MIS48 = result.MIS48,
                            SMT = result.SMT,
                            LocationCode = result.LocationCode,
                            FilteredVehicleModel = result.FilteredVehicleModel,
                            FaultCode = result.FaultCode,
                            BreakPointNum = "0".ToString(),
                            BreakPointTime = "BFI", // 断点时间为"new"
                            BreakPointTotal = relevantBreakpoints.Count.ToString(),//添加断点总数，为后续分离断点失效产品，做次数统计，
                        };
                        resultToStoreQuery.Add(newZeroBreakpointResult); // 将该初始化为0的实例添加到结果列表中，便于后续的断点分离，作为分离的新问题的种子

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
                                IssueAttributes = result.IssueAttributes,
                                CaseCount = result.CaseCount,
                                CumulativeCaseCount = result.CumulativeCaseCount,
                                MIS3 = result.MIS3,
                                MIS6 = result.MIS6,
                                MIS12 = result.MIS12,
                                MIS24 = result.MIS24,
                                MIS48 = result.MIS48,
                                SMT = result.SMT,
                                FilteredVehicleModel = result.FilteredVehicleModel,
                                LocationCode = result.LocationCode,
                                FaultCode = result.FaultCode,
                                BreakPointNum = (relevantBreakpoints.IndexOf(breakpoint) + 1).ToString(), // 断点编号从1开始，如果有两项则会出现多次断点
                                BreakPointTime = breakpoint.BreakpointTime,
                            };
                            // 添加新的实例到结果列表中
                            resultToStoreQuery.Add(newResult);
                            //将需要执行断点分离的项，进行重新组合，加入resultToQuery表，这里的resultToQuery就会添加断点分析表中所有的满足车型、物料号、供应商的项，为了后面去分离相应的断点区间
                        }
                    }
                }
                _logger.LogError("+++++++++++++++++++++++++++++++++++++++++分离断点处理表，符合要求的项数" + resultToStoreQuery.Count.ToString()+"打印查询表");
                foreach (var result in resultToStoreQuery)
                {
                    // 打印每个物料号的信息
                    Console.WriteLine($"物料号: {result.OldMaterialCode}, " +
                                           $"断点时间: {result.BreakPointTime}, " +
                                           $"断点次数: {result.BreakPointNum}, " +
                                           $"车型: {result.VehicleModel}, " +
                                           //$"审批日期: {result.ApprovalDate}, " +
                                           //$"物料描述: {result.OldMaterialDescription}, " +
                                           $"供应商短代码: {result.SupplierShortCode}, " +
                                           $"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                           $"案例数: {result.CaseCount}, " +
                                           $"MIS3: {result.MIS3}, " +
                                           $"MIS6: {result.MIS6}, " +
                                           $"MIS12: {result.MIS12}, " +
                                           $"MIS24: {result.MIS24}, " +
                                           $"MIS48: {result.MIS48}, " +
                                           //$"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                           //$"SMT: {result.SMT}, " +
                                           //$"位置代码: {result.LocationCode}, " +
                                           $"故障代码: {result.FaultCode}");
                    result.CaseCount = "-1";//当case count =-1，时，代表系统未进入，后期，直接抛弃，不会重新设立为新问题,这里改为即将执行断点分离的表
                }

                foreach (var duplicate in resultToStoreQuery.ToList()) // 使用 ToList() 避免在遍历时修改集合
                {
              
                    string tempcode = $"{duplicate.OldMaterialCode}-{duplicate?.SupplierShortCode}-{duplicate?.FilteredVehicleModel}";
                    // 如果存在重复项并且该物料号尚未被添加过
                    if ( !seenMaterialCodes.Contains(tempcode))
                    {   
                        seenMaterialCodes.Add(tempcode); //HASH 表用于存放相同的物料号，车型，供应商编号
                    }                   
                }
                //foreach (var s in seenMaterialCodes)
                //{

                //    Console.WriteLine($"AHASH to remove: {s}");
                //}
                //foreach (var r in resultsToStore)
                //{
                //    string tempcode = $"{r.OldMaterialCode}-{r.SupplierShortCode}-{r.FilteredVehicleModel}";
                //    Console.WriteLine($"Attempting to remove: {tempcode}");
                //}
                resultsToStore.RemoveAll(r =>
                {
                    string tempcode = $"{r.OldMaterialCode}-{r.SupplierShortCode}-{r.FilteredVehicleModel}";
                    return seenMaterialCodes.Contains(tempcode);
                });
                // 从 resultsToStore 中移除这些重复项，保留纯净的不需要分离断点的筛选结果,直接用于QE编辑             
                _logger.LogError("+++++++++++++++++++++++++++++++++++++++++++剩余不需要进行断点处理的列表" + resultsToStore.Count.ToString());
                // 遍历查询表用于执行断点分离，新问题直接提取，老问题按照区间分离
                foreach (var result in resultToStoreQuery)
                {
                    _logger.LogError($"遍历断点表之前的断点次数:{result.BreakPointNum},物料号：{result.OldMaterialCode},车型：{result.FilteredVehicleModel},供应商代码：{result.SupplierShortCode}" );
                    // 获取与物料号对应的所有断点,添加新增的判断
                    var relevantBreakpoints = convertedBreakpoints
                        .Where(b => b.OldMaterialCode == result.OldMaterialCode&&
                                    b.FilteredVehicleModel == result.FilteredVehicleModel&&
                                    b.SupplierShortCode ==result.SupplierShortCode)
                        .ToList();//这里重新新遍历断点表是为了统计问题的数量
                    //_logger.LogError($"物料号{result.OldMaterialCode}-车型{result.FilteredVehicleModel}-短代码:{result.SupplierShortCode}" +
                    //                 $"++++++++++++++++++++++++++综合个数{relevantBreakpoints.Count}");
                    //这是储存的每个物料号的断点的数量，至少应该是1个，重复列表才会是两个


                    if (relevantBreakpoints.Any())

                    {
                        _logger.LogError("此时集合的断点次数---" + result.BreakPointNum);
                        var queryCode = stepDataQuery.Where(b => b.OldMaterialCode == result.OldMaterialCode&&
                                                         b.SupplierShortCode ==result.SupplierShortCode&&
                                                         b.FilteredVehicleModel ==result.FilteredVehicleModel);
                                                        //定义一个特定的物料号，现在增加筛选车型和供应商
                        int mis3, mis6, mis12, mis24, mis48;
                        mis3 = mis6 = mis12 = mis24 = mis48 = 0;
                        foreach (var queryItem in queryCode)//用手写4次断点几乎涵盖所有情况，每次遍历物料号就可以写入下面 BreakPointNum对应的值进入duplicateMaterialCodes表
                        {
                            string manufactureMonth = queryItem.ManufacturingMonth ?? "0";
                            if (relevantBreakpoints.Count == 1)
                            {
                                string startDateStr1 = relevantBreakpoints[0].BreakpointTime ?? "0";
                                // _logger.LogError("找到断点为1");

                                if (result.BreakPointNum == "1")
                                {
                                    //_logger.LogError("--++++++++进入断点分离，确认分旧产品--------");
                                    //断点时间大于等于制造月,断点前产品
                                    if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                    {

                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {
                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;

                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;

                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;

                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                      
                                            result.MIS3 = mis3.ToString();                                  
                                            result.MIS6 = (mis6 + mis3).ToString();                                       
                                            result.MIS12 = (mis6 + mis3 + mis12).ToString();                                       
                                            result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();                                   
                                            result.MIS48 = mis48.ToString();
                                            result.CaseCount = mis48.ToString();

                                    }

                                }
                                else  //断点时间小于制造月，断点之后产品，断点失效
                                {

                                    //_logger.LogError("--++++++++进入断点分离，确认分离新产品-----------");
                                    if (startDateStr1.CompareTo(manufactureMonth) < 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1"  )
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                          
                                            result.MIS3 = mis3.ToString();
                                            result.MIS6 = (mis6 + mis3).ToString();
                                            result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                            result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                            result.MIS48 = mis48.ToString();
                                            result.CaseCount = mis48.ToString();
                                    }
                                }
                            }
                            else if (relevantBreakpoints.Count == 2)
                            {
                                string startDateStr1 = relevantBreakpoints[0].BreakpointTime ?? "0";
                                string startDateStr2 = relevantBreakpoints[1].BreakpointTime ?? "0";
                                //  _logger.LogError("找到断点为2");
                                if (result.BreakPointNum == "1")
                                {

                                    //断点时间大于等于制造月,断点前产品
                                    if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }

                                }
                                else if (result.BreakPointNum == "2")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else
                                {
                                    if (startDateStr2.CompareTo(manufactureMonth) < 0)
                                    {
                                        //2次断点时间小于制造月，2次断点失效产品
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString(); ;

                                    }

                                }

                            }
                            else if (relevantBreakpoints.Count == 3)
                            {
                                //  _logger.LogError("找到断点为3");
                                string startDateStr1 = relevantBreakpoints[0].BreakpointTime ?? "0";
                                string startDateStr2 = relevantBreakpoints[1].BreakpointTime ?? "0";
                                string startDateStr3 = relevantBreakpoints[2].BreakpointTime ?? "0";
                                if (result.BreakPointNum == "1")
                                {

                                    //断点时间大于等于制造月,断点前产品
                                    if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }

                                }
                                else if (result.BreakPointNum == "2")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else if (result.BreakPointNum == "3")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else
                                {
                                    if (startDateStr3.CompareTo(manufactureMonth) < 0)
                                    {
                                        //2次断点时间小于制造月，2次断点失效产品
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }

                                }

                            }
                            else if (relevantBreakpoints.Count == 4)
                            {
                                // _logger.LogError("找到断点为4");
                                string startDateStr1 = relevantBreakpoints[0].BreakpointTime ?? "0";
                                string startDateStr2 = relevantBreakpoints[1].BreakpointTime ?? "0";
                                string startDateStr3 = relevantBreakpoints[2].BreakpointTime ?? "0";
                                string startDateStr4 = relevantBreakpoints[3].BreakpointTime ?? "0";
                                if (result.BreakPointNum == "1")
                                {

                                    //断点时间大于等于制造月,断点前产品
                                    if (startDateStr1.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }

                                }
                                else if (result.BreakPointNum == "2")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr1.CompareTo(manufactureMonth) < 0 && startDateStr2.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else if (result.BreakPointNum == "3")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr2.CompareTo(manufactureMonth) < 0 && startDateStr3.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else if (result.BreakPointNum == "4")
                                {  // 1次断点时间小于制造月，2次断点时间大于制造月，介于1次断点到2次断点间的产品
                                    if (startDateStr3.CompareTo(manufactureMonth) < 0 && startDateStr4.CompareTo(manufactureMonth) >= 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3")
                                        {


                                            mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;



                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;



                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;



                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }
                                }
                                else
                                {
                                    if (startDateStr4.CompareTo(manufactureMonth) < 0)
                                    {
                                        if (queryItem.MISInterval == "0" || queryItem.MISInterval == "3" || queryItem.MISInterval == "-1")
                                        {

                                             mis3++;

                                        }
                                        else if (queryItem.MISInterval == "6")
                                        {
                                            mis6++;

                                        }
                                        else if (queryItem.MISInterval == "12")
                                        {
                                            mis12++;
                                        }
                                        else if (queryItem.MISInterval == "24")
                                        {
                                            mis24++;
                                        }
                                        mis48++;//技术中心试验车的情况，后期需要排除
                                        result.MIS3 = mis3.ToString();
                                        result.MIS6 = (mis6 + mis3).ToString();
                                        result.MIS12 = (mis6 + mis3 + mis12).ToString();
                                        result.MIS24 = (mis6 + mis3 + mis12 + mis24).ToString();
                                        result.MIS48 = mis48.ToString();
                                        result.CaseCount = mis48.ToString();

                                    }

                                }

                            }
                        }

                        // 例如将这些值存储到 result 中或进行其他逻辑处理
                    }
                }//对断点分离的结果进行正确的填充

                foreach (var item in resultToStoreQuery.ToList())
                {

                    if (item.CaseCount != "-1") //如果总案例数被标记为-1，则直接删除，为断点分离的种子并且处于失效状态
                    {
                        if (item.BreakPointNum == "0")
                        {
                            item.BreakPointNum = item.BreakPointTotal;//将为 初始化 断点为0的种子，让其加入重新编辑的数据，并标识第几次断点失效
                            resultsToStore.Add(item);
                        }
                        else
                            resultToStoreEditAndQuery.Add(item);
                    }
                }
                _logger.LogError("+++++++++++++++++++++++++++++++++++++++++++经过处理的重复断点列表已加入到最终结果中" + resultsToStore.Count.ToString());

                // 整理最终结果，按 OldMaterialCode 分组，汇总 CaseCount 和 MISValues，并分配自然排序 Order
                _logger.LogError("开始打印最终的结果+++++++++++++++++++++++++++++++++++");
                foreach (var result in resultsToStore)
                {
                    // 打印每个物料号的信息
                    Console.WriteLine($"物料号: {result.OldMaterialCode}, " +
                                           $"断点时间: {result.BreakPointTime}, " +
                                           $"断点次数: {result.BreakPointNum}, " +
                                           $"车型: {result.VehicleModel}, " +
                                           //$"审批日期: {result.ApprovalDate}, " +
                                           //$"物料描述: {result.OldMaterialDescription}, " +
                                           $"供应商短代码: {result.SupplierShortCode}, " +
                                           //$"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                           $"案例数: {result.CaseCount}, " +
                                           $"MIS3: {result.MIS3}, " +
                                           $"MIS6: {result.MIS6}, " +
                                           $"MIS12: {result.MIS12}, " +
                                           $"MIS24: {result.MIS24}, " +
                                           $"MIS48: {result.MIS48}, " +
                                           //$"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                           //$"SMT: {result.SMT}, " +
                                           //$"位置代码: {result.LocationCode}, " +
                                           $"故障代码: {result.FaultCode}");
                }
                _logger.LogError("开始打印查询表结果，分离断点后不需要处理的问题或者老问题+++++++++++++++++++++++++++++++++++");
                foreach (var result in resultToStoreEditAndQuery)
                {
                    // 打印每个物料号的信息
                    Console.WriteLine($"物料号: {result.OldMaterialCode}, " +
                                           $"断点时间: {result.BreakPointTime}, " +
                                           $"断点次数: {result.BreakPointNum}, " +
                                           $"车型: {result.VehicleModel}, " +
                                           //$"审批日期: {result.ApprovalDate}, " +
                                           //$"物料描述: {result.OldMaterialDescription}, " +
                                           $"供应商短代码: {result.SupplierShortCode}, " +
                                           //$"责任源供应商: {result.ResponsibilitySourceSupplierName}, " +
                                           $"案例数: {result.CaseCount}, " +
                                           $"MIS3: {result.MIS3}, " +
                                           $"MIS6: {result.MIS6}, " +
                                           $"MIS12: {result.MIS12}, " +
                                           $"MIS24: {result.MIS24}, " +
                                           $"MIS48: {result.MIS48}, " +
                                           //$"CumulativeCaseCount: {result.CumulativeCaseCount}, " +
                                           //$"SMT: {result.SMT}, " +
                                           //$"位置代码: {result.LocationCode}, " +
                                           $"故障代码: {result.FaultCode}");
                }

                await ProcessAndStoreResultsAsyncToQuery(resultToStoreEditAndQuery);
                await ProcessAndStoreResultsV91TempAsync(resultsToStore);
                //添加额外的打印
              

                return Ok(new
                {
                    ResultToStoreQuery = resultToStoreEditAndQuery,

                    ResultsToStore = resultsToStore
                });
            }





            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering and pivoting data.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("TransferV91Data")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> TransferV91Data([FromForm] DataOperation operation)
        {
            var dbSetTemp = _context.dailyQualityIssueChecklistV91Temps;
            var dbSetPermanent = _context.DailyQualityIssueChecklistV91s;

            // 开始事务以确保数据一致性
            using var transaction = await _context.Database.BeginTransactionAsync();//避免数据回滚
            try
            {
                switch (operation)
                {
                    case DataOperation.Replace:
                        if (await dbSetPermanent.AnyAsync())
                        {
                            _context.DailyQualityIssueChecklistV91s.RemoveRange(dbSetPermanent);
                            await _context.SaveChangesAsync();
                            _logger.LogInformation("成功清空 DailyQualityIssueChecklistV91 表。");
                        }
                        break;

                    case DataOperation.Update:
                        // 保持现有数据，无需清空
                        break;

                    default:
                        return BadRequest("无效的操作类型。");
                }

                // 从临时表中读取数据
                var tempData = await dbSetTemp.ToListAsync();
                _logger.LogInformation($"从 DailyQualityIssueChecklistV91Temp 读取到 {tempData.Count} 条记录。");

                // 从永久表中读取现有数据
                var originData = await dbSetPermanent.ToListAsync();
                _logger.LogInformation($"从 DailyQualityIssueChecklistV91s 读取到 {originData.Count} 条记录。");

                // 初始化计数器
                int updateData = 0;
                int addData = 0;

                // 映射临时数据到永久实体
                List<DailyQualityIssueChecklistV91> permanentEntriesToAdd = new List<DailyQualityIssueChecklistV91>();

                foreach (var temp in tempData)
                {
                    // 查找与当前temp数据匹配的原始数据
                    var matchingRecords = originData.Where(e =>
                        e.OldMaterialCode == temp.OldMaterialCode &&
                        e.SupplierShortCode == temp.SupplierShortCode &&
                        e.BreakdownCount == temp.BreakdownCount &&
                        e.FilteredVehicleModel == temp.FilteredVehicleModel).ToList();

                    if (matchingRecords.Any())  // 满足条件的项，进行更新累加
                    {
                        foreach (var match in matchingRecords)
                        {
                            // 解析并累加数值字段
                            temp.CaseCount = match.CaseCount;
                            temp.MIS3 = match.MIS3;
                            temp.MIS6 = match.MIS6;
                            temp.MIS12 = match.MIS12;
                            temp.MIS24 = match.MIS24;
                            temp.MIS48 = match.MIS48;

                            // 更新记录
                            _context.DailyQualityIssueChecklistV91s.Update(match);

                            // 记录日志，确保使用正确的变量名
                            _logger.LogInformation($"更新的项为：{match.OldMaterialCode}-{match.SupplierShortCode}-{match.FilteredVehicleModel}-{match.BreakdownCount}。" +
                                $"更新后的数据为MIS3={match.MIS3}," +
                                $" MIS6={match.MIS6}," +
                                $" MIS12={match.MIS12}," +
                                $" MIS24={match.MIS24}," +
                                $" MIS48={match.MIS48}。");
                        }
                        updateData++;
                    }
                    else  // 不满足条件的项，建立新的实例
                    {
                        // 创建新的实例并添加到永久表插入列表
                        var permanentEntry = new DailyQualityIssueChecklistV91
                        {
                            OldMaterialCode = temp.OldMaterialCode ?? "NIL",
                            OldMaterialDescription = temp.OldMaterialDescription ?? "NIL",
                            SupplierShortCode = temp.SupplierShortCode ?? "NIL",
                            ResponsibilitySourceSupplierName = temp.ResponsibilitySourceSupplierName ?? "NIL",
                            FilteredVehicleModel = temp.FilteredVehicleModel ?? "NIL",
                            IssueAttributes = temp.IssueAttributes??"NIL",
                            CaseCount = temp.CaseCount ?? "0",
                            MIS3 = temp.MIS3 ?? "0",
                            MIS6 = temp.MIS6 ?? "0",
                            MIS12 = temp.MIS12 ?? "0",
                            MIS24 = temp.MIS24 ?? "0",
                            MIS48 = temp.MIS48 ?? "0",
                            SMT = temp.SMT ?? "NIL",
                            LocationCode = temp.LocationCode ?? "NIL",
                            FaultCode = temp.FaultCode ?? "NIL",
                            PQSNumber = temp.PQSNumber ?? "NIL",
                            BreakdownCount = temp.BreakdownCount ?? "NIL",
                            IsBreakdownInvalid = temp.IsBreakdownInvalid ?? "NIL",
                            BreakpointTime = temp.BreakpointTime ?? "NIL",
                            // 其他必要字段的赋值
                        };
                        addData++;
                        permanentEntriesToAdd.Add(permanentEntry);
                    }
                }

                // 将新增的记录添加到永久表
                if (permanentEntriesToAdd.Any())
                {
                    await dbSetPermanent.AddRangeAsync(permanentEntriesToAdd);
                    _logger.LogInformation($"准备添加 {permanentEntriesToAdd.Count} 条新记录到 DailyQualityIssueChecklistV91 表。");
                }

                // 一次性提交所有更改
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"数据传输完成，查询记录{originData.Count},处理记录{tempData.Count},更新数据{updateData},新增数据{addData}");
                return Ok(new { Message =$"数据传输完成，查询记录{originData.Count},处理记录{tempData.Count},更新数据{updateData},新增数据{addData}", InsertedRecords = permanentEntriesToAdd.Count });
            }
            catch (Exception ex)
            {
                // 回滚事务
                await transaction.RollbackAsync();
                _logger.LogError(ex, "数据传输过程中发生错误，事务已回滚。");
                return StatusCode(500, "内部服务器错误。");
            }
        }


        /// <summary>
        /// 从 DailyQualityIssueChecklistV91QueryTemp 临时表传输数据到 DailyQualityIssueChecklistV91Query 永久表。
        /// </summary>
        /// <param name="operation">操作类型：Replace（替换）或 Update（更新）。</param>
        /// <returns>操作结果。</returns>
        [HttpPost("TransferV91QueryData")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> TransferV91QueryData([FromForm] DataOperation operation)
        {
            var dbSetTemp = _context.dailyQualityIssueChecklistV91QueryTemps;
            var dbSetPermanent = _context.DailyQualityIssueChecklistV91Queries;

            switch (operation)
            {
                case DataOperation.Replace:
                    if (await dbSetPermanent.AnyAsync())
                    {
                        _context.DailyQualityIssueChecklistV91Queries.RemoveRange(dbSetPermanent);
                        await _context.SaveChangesAsync();
                        _logger.LogError("成功清空 DailyQualityIssueChecklistV91Query 表。");
                    }
                    break;

                case DataOperation.Update:
                    // 保持现有数据，无需清空
                    break;

                default:
                    return BadRequest("无效的操作类型。");
            }

            // 从临时表中读取数据
            var tempData = await dbSetTemp.ToListAsync();

            //从原有表中记录数据
            var originData = await dbSetPermanent.ToListAsync();
            var updateData = 0;
            var addData = 0;
            _logger.LogError($"从 DailyQualityIssueChecklistV91Queries 读取到 {originData.Count} 条记录。");
            _logger.LogError($"从 DailyQualityIssueChecklistV91QueryTemp 读取到 {tempData.Count} 条记录。");

            // 映射临时数据到永久实体
            List<DailyQualityIssueChecklistV91Query> permanentEntries = new List<DailyQualityIssueChecklistV91Query>();


            foreach (var temp in tempData)
            {
                // 查找与当前temp数据匹配的原始数据
                var saveData = originData.Where(e => e.OldMaterialCode == temp.OldMaterialCode &&
                                                     e.SupplierShortCode == temp.SupplierShortCode &&
                                                     e.BreakPointNum == temp.BreakPointNum &&
                                                     e.VehicleModel == temp.VehicleModel)
                                         .ToList();

                if (saveData.Any())  // 满足条件的项，进行更新累加
                {
                    foreach (var match in saveData)
                    {

                        temp.CaseCount = match.CaseCount;
                        temp.MIS3 = match.MIS3;
                        temp.MIS6 = match.MIS6;
                        temp.MIS12 = match.MIS12;
                        temp.MIS24 = match.MIS24;
                        temp.MIS48 = match.MIS48;

                        _context.DailyQualityIssueChecklistV91Queries.Update(match);
                        // Add the updated record to the update list,更新数据库的对应项
                        _logger.LogError($"更新的项为：{match.OldMaterialCode}-{match.SupplierShortCode}-{match.VehicleModel}-{match.BreakPointNum}" +
                            $"更新前的数据为{temp.MIS3}+{temp.MIS6}+{temp.MIS12}+{temp.MIS24}+{temp.MIS48},更新后的数据为{match.MIS3}+{match.MIS6}+{match.MIS12}+{match.MIS24}+{match.MIS48}");

                    }
                    updateData++;
                    await _context.SaveChangesAsync();  // 提交更改到数据库
                }
                else  // 不满足条件的项，建立新的实例
                {
                    // 创建新的实例并添加到永久表插入列表
                    var permanentEntry = new DailyQualityIssueChecklistV91Query
                    {
                        OldMaterialCode = temp.OldMaterialCode ?? "NIL",
                        ApprovalDate = temp.ApprovalDate ?? "NIL",
                        VehicleModel = temp.VehicleModel ?? "NIL",
                        OldMaterialDescription = temp.OldMaterialDescription ?? "NIL",
                        SupplierShortCode = temp.SupplierShortCode ?? "NIL",
                        ResponsibilitySourceSupplierName = temp.ResponsibilitySourceSupplierName ?? "NIL",
                        CaseCount = temp.CaseCount ?? "NIL",
                        BreakPointNum = temp.BreakPointNum ?? "NIL",
                        IssueAttributes = temp.IssueAttributes ?? "NIL",
                        MIS3 = temp.MIS3 ?? "0",
                        MIS6 = temp.MIS6 ?? "0",
                        MIS12 = temp.MIS12 ?? "0",
                        MIS24 = temp.MIS24 ?? "0",
                        MIS48 = temp.MIS48 ?? "0",
                        SMT = temp.SMT ?? "NIL",
                        LocationCode = temp.LocationCode ?? "NIL", 
                        FaultCode = temp.FaultCode ?? "NIL",
                        PQSNumber = temp.PQSNumber ?? "NIL",
                        VAN = temp.VAN ?? "NIL",
                        VIN = temp.VIN ?? "NIL"
                    };
                    addData++;
                    permanentEntries.Add(permanentEntry); // Add the new record to the add list
                }
            }

            // 将数据添加到永久表
            if (permanentEntries.Any())
            {
                await dbSetPermanent.AddRangeAsync(permanentEntries);
                await _context.SaveChangesAsync();
                _logger.LogError($"成功将 {permanentEntries.Count} 条记录写入 DailyQualityIssueChecklistV91Query 表。");
            }
            else
            {
                _logger.LogError("没有可插入的记录。");
            }

            return Ok(new { Message = $"数据传输完成，查询记录{originData.Count},处理记录{tempData.Count},更新数据{updateData},新增数据{addData}", InsertedRecords = permanentEntries.Count });
        }




        public async Task ProcessAndStoreResultsAsyncToQuery(IEnumerable<PivotResult> resultsToStoreQuery)
        {
            // Step 1: 对 resultsToStoreQuery 进行排序
            var sortedResults = resultsToStoreQuery
                .OrderBy(r =>
                {
                    // 尝试将 ApprovalDate 转换为 DateTime，如果失败则使用 DateTime.MaxValue
                    return DateTime.TryParse(r.ApprovalDate, out DateTime date) ? date : DateTime.MaxValue;
                })
                .ToList();

            // Step 2: 遍历排序后的结果，创建 tempEntries 列表
            List<DailyQualityIssueChecklistV91QueryTemp> tempEntries = new List<DailyQualityIssueChecklistV91QueryTemp>();

            foreach (var result in sortedResults)
            {
                var tempEntry = new DailyQualityIssueChecklistV91QueryTemp
                {
                    OldMaterialCode = result.OldMaterialCode ?? "NIL",
                    ApprovalDate = result.ApprovalDate ?? "NIL",
                    VehicleModel = result.VehicleModel ?? "NIL",
                    OldMaterialDescription = result.OldMaterialDescription ?? "NIL",
                    SupplierShortCode = result.SupplierShortCode ?? "NIL",
                    ResponsibilitySourceSupplierName = result.ResponsibilitySourceSupplierName ?? "NIL",
                    IssueAttributes = result.IssueAttributes ??"NIL",
                    CaseCount = result.CaseCount ?? "NIL",
                    BreakPointNum = result.BreakPointNum, // 没有对应的字段，设置为 "NIL"
                    MIS3 = result.MIS3 ?? "0", // 根据业务需求设置默认值
                    MIS6 = result.MIS6 ?? "0",
                    MIS12 = result.MIS12 ?? "0",
                    MIS24 = result.MIS24 ?? "0",
                    MIS48 = result.MIS48 ?? "0",
                    SMT = result.SMT ?? "NIL",
                    LocationCode = result.LocationCode ?? "NIL",
                    FaultCode = result.FaultCode ?? "NIL",
                    PQSNumber = "NIL", // 没有对应的字段，设置为 "NIL"
                    VAN = "NIL", // 没有对应的字段，设置为 "NIL"
                    VIN = "NIL" // 没有对应的字段，设置为 "NIL"
                };

                tempEntries.Add(tempEntry);
            }

            _logger.LogError($"排序后记录数: {sortedResults.Count}");

            // Step 3: 使用事务清空表并插入新数据
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogError("开始清空 DailyQualityIssueChecklistV91QueryTemps 表。");

                    // 方法1：使用 RemoveRange 删除所有记录
                    _context.dailyQualityIssueChecklistV91QueryTemps.RemoveRange(_context.dailyQualityIssueChecklistV91QueryTemps);
                    await _context.SaveChangesAsync();
                    _logger.LogError("成功清空 DailyQualityIssueChecklistV91QueryTemps 表。");

                    // 或者使用原生 SQL 命令（方法2：使用 ExecuteSqlRawAsync）
                    // await _context.Database.ExecuteSqlRawAsync("DELETE FROM [YourSchema].[DailyQualityIssueChecklistV91QueryTemps]");
                    // _logger.LogError("成功清空 DailyQualityIssueChecklistV91QueryTemps 表。");

                    // 批量添加新数据
                    if (tempEntries.Any())
                    {
                        _logger.LogError($"准备添加新数据，记录数: {tempEntries.Count}");
                        await _context.dailyQualityIssueChecklistV91QueryTemps.AddRangeAsync(tempEntries);
                        await _context.SaveChangesAsync();
                        _logger.LogError("成功将数据写入 DailyQualityIssueChecklistV91QueryTemps 表。");
                    }

                    // 提交事务
                    await transaction.CommitAsync();
                    _logger.LogError("事务已提交。");
                }
                catch (Exception ex)
                {
                    // 回滚事务
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "在清空或写入 DailyQualityIssueChecklistV91QueryTemps 表时发生错误。事务已回滚。");
                    // 根据业务需求，可能需要进一步处理异常，如通知管理员或触发重试机制
                }
            }
        }

        public async Task ProcessAndStoreResultsV91TempAsync(IEnumerable<PivotResult> resultsToStore)
        {
            // Step 1: 对 resultsToStore 进行排序
            var sortedResults = resultsToStore
            .OrderByDescending(r => int.TryParse(r.BreakPointNum, out var num) ? num : int.MinValue)  // 按照断点次数降序排序，非数字的按最小值处理
            .ToList();


            // Step 2: 遍历排序后的结果，创建 tempEntries 列表
            List<DailyQualityIssueChecklistV91Temp> tempEntries = new List<DailyQualityIssueChecklistV91Temp>();

            foreach (var result in sortedResults)
            {
                string isBreakdownInvalid = (result.BreakPointNum == "0") ? "否" : "是";//这里可以根据之前定义的断点种子分别判断断点是否失效
                string tempCount = (result.BreakPointNum == "0") ? result.BreakPointTotal : result.BreakPointNum;
                var tempEntry = new DailyQualityIssueChecklistV91Temp
                {
                    ApprovalDate = result.ApprovalDate ?? "NIL",
                    OldMaterialCode = result.OldMaterialCode ?? "NIL",
                    OldMaterialDescription = result.OldMaterialDescription ?? "NIL",
                    SupplierShortCode = result.SupplierShortCode ?? "NIL",
                    ResponsibilitySourceSupplierName = result.ResponsibilitySourceSupplierName ?? "NIL",
                    FilteredVehicleModel= result.FilteredVehicleModel ??"NIL",
                    IssueAttributes = result.IssueAttributes ??"NIL",
                    CaseCount = result.CaseCount ?? "NIL",
                    MIS3 = result.MIS3 ?? "0",
                    MIS6 = result.MIS6 ?? "0",
                    MIS12 = result.MIS12 ?? "0",
                    MIS24 = result.MIS24 ?? "0",
                    MIS48 = result.MIS48 ?? "0",
                    SMT = result.SMT ?? "NIL",
                    LocationCode = result.LocationCode ?? "NIL",
                    FaultCode = result.FaultCode ?? "NIL",
                    QE = "NIL", // 没有对应的字段，设置为 "NIL"
                    ServiceFaultIdentificationAccurate = "NIL", // 没有对应的字段，设置为 "NIL"
                    IdentifiedFaultMode = "NIL", // 没有对应的字段，设置为 "NIL"                
                    BreakdownCount = tempCount??"NQI",//为断点次数 为0 的情况下赋值之前定义的总次数                               
                    IsBreakdownInvalid = isBreakdownInvalid,
                    IncludedInSIL = "NIL", // 没有对应的字段，设置为 "NIL"
                    PQSNumber = "NIL", // 没有对应的字段，设置为 "NIL"
                    BreakpointTime = result.BreakPointTime ?? "0", // 没有对应的字段，设置为 "0"
                    StartTime = "NIL", // 没有对应的字段，设置为 "NIL"
                    Remarks = "NIL", // 没有对应的字段，设置为 "NIL"
                    ProjectIdentifier = "NIL" // 没有对应的字段，设置为 "NIL"
                };

                tempEntries.Add(tempEntry);
            }

            _logger.LogError($"排序前记录数: {sortedResults.Count}");

            // Step 3: 使用事务清空表并插入新数据
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // 清空表（方法1：使用 RemoveRange 删除所有记录）
                    _context.dailyQualityIssueChecklistV91Temps.RemoveRange(_context.dailyQualityIssueChecklistV91Temps);
                    await _context.SaveChangesAsync();
                    _logger.LogError("成功清空 DailyQualityIssueChecklistV91Temps 表。");

                    // 或者使用原生 SQL 命令（方法2：使用 ExecuteSqlRawAsync）
                    // await _context.Database.ExecuteSqlRawAsync("DELETE FROM [JRZKWTWebWinMVC].[dbo].[DailyQualityIssueChecklistV91Temps]");
                    // _logger.LogError("成功清空 DailyQualityIssueChecklistV91Temps 表。");

                    // 批量添加新数据
                    if (tempEntries.Any())
                    {
                        await _context.dailyQualityIssueChecklistV91Temps.AddRangeAsync(tempEntries);
                        await _context.SaveChangesAsync();
                        _logger.LogError("成功将数据写入 DailyQualityIssueChecklistV91Temps 表。");
                    }

                    // 提交事务
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // 回滚事务
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "在清空或写入 DailyQualityIssueChecklistV91Temps 表时发生错误。事务已回滚。");
                    // 根据业务需求，可能需要进一步处理异常，如通知管理员或触发重试机制
                }
            }
        }




    }
}
