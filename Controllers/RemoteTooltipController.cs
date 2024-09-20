using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebWinMVC.Controllers
{
    [Route("queryAPI/[controller]")]
    [ApiController]
    public class RemoteTooltipController : ControllerBase
    {
        private readonly JRZLWTDbContext _context;

        public RemoteTooltipController(JRZLWTDbContext context)
        {
            _context = context;
        }
        [HttpGet("tooltipdata")]
        public async Task<IActionResult> GetTooltipData([FromQuery] string oldMaterialCode, [FromQuery] string dateRange = "")
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
                })
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound($"No data found for the provided OldMaterialCode, and the processed date range is: NONE");
            }

            return Ok(data);
        }


    }
}

