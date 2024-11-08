﻿using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data; // 引用您的数据上下文命名空间
using WebWinMVC.Models; // 引用您的模型命名空间
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinMVC.Controllers
{
    public class RemoteEditController : Controller
    {
        private readonly JRZLWTDbContext _context;

        public RemoteEditController(JRZLWTDbContext context)
        {
            _context = context;
        }

        // 获取详情用于填充表单
        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++" + "开始编辑");
            var record = _context.DailyQualityIssueChecklistV91s.Find(id);
            if (record != null)
            {
                return Json(new
                {
                    record.ID,
                    record.OldMaterialCode,
                    record.OldMaterialDescription,
                    record.SupplierShortCode,
                    record.ResponsibilitySourceSupplierName,
                    record.MIS3,
                    record.MIS6,
                    record.MIS12,
                    record.MIS24,
                    record.MIS48,
                    record.SMT,
                    record.LocationCode,
                    record.FaultCode,
                    record.QE,
                    record.IdentifiedFaultMode,
                    record.BreakdownCount,
                    record.IsBreakdownInvalid,
                    record.IncludedInSIL,
                    record.PQSNumber,
                    record.BreakpointTime,
                    record.StartTime,
                    record.Remarks,
                    record.ServiceFaultIdentificationAccurate,
                    record.ProjectIdentifier,
                    RowVersion = Convert.ToBase64String(record.RowVersion) // 转换为 Base64 字符串
                });
            }
            return Json(new { success = false, message = "记录未找到" });
        }

        // 处理编辑请求
        [HttpPost]
        [ValidateAntiForgeryToken] // 添加防伪令牌验证
        public async Task<IActionResult> Edit(DailyQualityIssueChecklistV91 model, string RowVersion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 手动转换 RowVersion 从 Base64 字符串到 byte[]
                    if (!string.IsNullOrEmpty(RowVersion))
                    {
                        model.RowVersion = Convert.FromBase64String(RowVersion);
                    }

                    // 绑定 RowVersion
                    _context.Entry(model).Property("RowVersion").OriginalValue = model.RowVersion;

                    // 更新记录
                    _context.DailyQualityIssueChecklistV91s.Update(model);

                    // 保存更改，可能会抛出 DbUpdateConcurrencyException
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }
                catch (DbUpdateConcurrencyException)
                {
                    // 获取并发冲突的实体
                    var entry = _context.Entry(model);
                    var databaseEntry = await entry.GetDatabaseValuesAsync();
                    if (databaseEntry == null)
                    {
                        // 数据已被删除
                        return Json(new { success = false, message = "记录已被删除。" });
                    }

                    var databaseValues = (DailyQualityIssueChecklistV91)databaseEntry.ToObject();

                    // 返回并发冲突信息和数据库的最新值
                    return Json(new
                    {
                        success = false,
                        message = "并发冲突：该记录已被其他用户修改。",
                        databasevalues = new
                        {
                            databaseValues.ID,
                            databaseValues.OldMaterialCode,
                            databaseValues.OldMaterialDescription,
                            databaseValues.SupplierShortCode,
                            databaseValues.ResponsibilitySourceSupplierName,
                            databaseValues.MIS3,
                            databaseValues.MIS6,
                            databaseValues.MIS12,
                            databaseValues.MIS24,
                            databaseValues.MIS48,
                            databaseValues.SMT,
                            databaseValues.LocationCode,
                            databaseValues.FaultCode,
                            databaseValues.QE,
                            databaseValues.IdentifiedFaultMode,
                            databaseValues.BreakdownCount,
                            databaseValues.IsBreakdownInvalid,
                            databaseValues.IncludedInSIL,
                            databaseValues.PQSNumber,
                            databaseValues.BreakpointTime,
                            databaseValues.StartTime,
                            databaseValues.Remarks,
                            databaseValues.ServiceFaultIdentificationAccurate,
                            databaseValues.ProjectIdentifier,
                            RowVersion = Convert.ToBase64String(databaseValues.RowVersion) // 转换为 Base64 字符串
                        }
                    });
                }
                catch (Exception ex)
                {
                    // 处理其他可能的异常
                    return Json(new { success = false, message = "服务器错误：" + ex.Message });
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "请填完整参数", errors });
        }
    }
}
