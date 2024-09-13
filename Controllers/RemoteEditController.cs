using Microsoft.AspNetCore.Mvc;
using WebWinMVC.Data; // 引用您的数据上下文命名空间
using WebWinMVC.Models; // 引用您的模型命名空间

namespace WebWinMVC.Controllers
{
    public class RemoteEditController : Controller
    {
        private readonly JRZLWTDbContext _context;

        public RemoteEditController(JRZLWTDbContext context)
        {
            _context = context;
        }

        // 处理编辑请求
        [HttpPost]
        public IActionResult Edit(DailyQualityIssueChecklistV91 model)
        {
            if (ModelState.IsValid)
            {
                var existingRecord = _context.DailyQualityIssueChecklistV91s.Find(model.ID);
                if (existingRecord != null)
                {
                    // 更新记录
                    existingRecord.OldMaterialCode = model.OldMaterialCode;
                    existingRecord.OldMaterialDescription = model.OldMaterialDescription;
                    existingRecord.SupplierShortCode = model.SupplierShortCode;
                    existingRecord.ResponsibilitySourceSupplierName = model.ResponsibilitySourceSupplierName;
                    existingRecord.MIS3 = model.MIS3;
                    existingRecord.MIS6 = model.MIS6;
                    existingRecord.MIS12 = model.MIS12;
                    existingRecord.MIS24 = model.MIS24;
                    existingRecord.MIS36 = model.MIS36;
                    existingRecord.SMT = model.SMT;
                    existingRecord.LocationCode = model.LocationCode;
                    existingRecord.FaultCode = model.FaultCode;
                    existingRecord.IdentifiedFaultMode = model.IdentifiedFaultMode;
                    existingRecord.IdentifiedFaultCode = model.IdentifiedFaultCode;
                    existingRecord.QE = model.QE;
                    existingRecord.IncludedInSIL = model.IncludedInSIL;
                    existingRecord.PQSNumber = model.PQSNumber;
                    existingRecord.BreakpointTime = model.BreakpointTime;
                    existingRecord.StartTime = model.StartTime;
                    existingRecord.Remarks = model.Remarks;
                    existingRecord.ServiceFaultIdentificationAccurate = model.ServiceFaultIdentificationAccurate;

                    // 保存更改
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "记录未找到" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message =  "请填完整参数", errors  });
            }

        // 获取详情用于填充表单
        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var record = _context.DailyQualityIssueChecklistV91s.Find(id);
            if (record != null)
            {
                return Json(record);
            }
            return Json(new { success = false, message = "记录未找到" });
        }
    }
}
