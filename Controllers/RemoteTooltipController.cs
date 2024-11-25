using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebWinMVC.Controllers
{
    [Route("queryAPI/[controller]")]
    [ApiController]
    [Authorize]
    public class RemoteTooltipController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;
        private readonly ILogger<RemoteTooltipController> _logger;
        public RemoteTooltipController(JRZLWTDbContext context, ILogger<RemoteTooltipController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("tooltipdata")]
        public async Task<IActionResult> GetTooltipData(
            [FromQuery] string oldMaterialCode,             
            [FromQuery] string supplierShortCode,
            [FromQuery] string filteredVehicleModel,
            [FromQuery] string dateRange = ""
            )
        {
            if (string.IsNullOrEmpty(oldMaterialCode))
            {
                return BadRequest("Invalid OldMaterialCode");
            }
            // 初始化查询
            var query = _context.DailyServiceReviewFormQueries
               .Where(e => e.OldMaterialCode == oldMaterialCode)
               .Where(e => e.SupplierShortCode == supplierShortCode)
               .Where(e => e.FilteredVehicleModel == filteredVehicleModel.ToString())
               .Where(e => e.ServiceCategory == "售前维修" || e.ServiceCategory == "质保服务")
               .Where(e => e.ResponsibilitySourceIdentifier == "是")
               .Where(e => e.RepairMethod == "更换" || e.RepairMethod == "维修")
               .Where(e => e.MaterialType == "物料");

            Console.WriteLine($"111111物料号：{oldMaterialCode}供应商短代码{supplierShortCode}筛选车型{filteredVehicleModel}");
            Console.WriteLine($"符合要求数量：{query.ToList().Count}");
            // 用于存储处理后的日期


            if (!string.IsNullOrEmpty(dateRange))
            {
                // 用于存储处理后的日期
                string? startDateStr = null;
                string? endDateStr = null;


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

            var data = await query
                .Select(e => new
                {
                    e.ManufacturingMonth,
                    e.MISInterval,
                    e.VAN,
                    e.MIS,
                    e.FDP,
                    e.FaultCodeDescription,
                    e.FaultDescription,
                    e.SalesDate,
                    e.ServiceOrder,
                    e.ResponsibilitySourceSupplierName,
                    e.FilteredVehicleModel,
                    e.OldMaterialCode,
                    e.SupplierShortCode,
                })
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound($"No data found for the provided OldMaterialCode, and the processed date range is: NONE");
            }

            return Ok(data);
        }

        [HttpGet("dataStoreFilter")]
        public IActionResult FindBreakpoints([FromQuery] string oldMaterialCode, [FromQuery] string filteredVehicleModel, [FromQuery] string supplierShortCode)
        {

            _logger.LogError("---进入断点表筛选相关断点");
            // 假设你有一个数据库表 breakpointAnalysisTables
            var breakpoints = _context.BreakpointAnalysisTables
                .Where(e => e.MaterialCode == oldMaterialCode
                            && e.FilteredVehicleModel == filteredVehicleModel
                            && e.SupplierShortCode == supplierShortCode
                            && e.BreakpointTime != null)
                .Select(e => e.BreakpointTime)
                .ToList();

            // 返回断点时间
            return Ok(new { breakpointTimes = breakpoints });
        }

    }



}

