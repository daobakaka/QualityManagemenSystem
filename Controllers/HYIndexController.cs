using WebWinMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebWinMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebWinMVC.Controllers
{
    [Authorize]
   // [Authorize(Policy = "JwtPolicy")] // 应用 JWT 认证策略 添加测试
    public class HYIndexController : Controller
    {
        private readonly ILogger<HYIndexController> _logger;
        private readonly JRZLWTDbContext _context;
        public HYIndexController(ILogger<HYIndexController> logger, JRZLWTDbContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        public IActionResult HYIndexJRZLWTV91()
        {
           if(string.IsNullOrEmpty( HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            var checklistsV91 = _context.DailyQualityIssueChecklistV91s.OrderBy(c => c.ID).ToList();
            var checklistsV91Queries = _context.DailyQualityIssueChecklistV91Queries.OrderBy(c => c.ID).ToList();
            var userAuthentications   =_context.userAuthentications.OrderBy(c => c.ID).ToList();
            //var dailyServiceReviewForms = _context.DailyServiceReviewForms.OrderBy(c => c.ID).ToList();
            // var dailyServiceReviewFormsQueries = _context.DailyServiceReviewFormQueries.OrderBy(c => c.ID).ToList();
    
             var viewModel = new JRZLWTViewModel
            {
              //  DailyServiceReviewForms = dailyServiceReviewForms,
               // DailyServiceReviewFormQueries = dailyServiceReviewFormsQueries,
                ChecklistV91s = checklistsV91,
                ChecklistV91Queries = checklistsV91Queries,
                UserAuthentications = userAuthentications,
                AdditionalInfo = "即日质量问题清单",
                //other configration
                //JRZLWTV91Headers = HeaderMappingUtil.GetHeaderMapping<DailyQualityIssueChecklistV91Map>(),//添加映射


            };

            return View(viewModel);
        }


        public IActionResult HYIndexSIL()
        {
            //viewBag 赋值模块

            //--
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            var sILSimulationTables = _context.SILSimulationTables.OrderBy(c => c.ID).ToList();
            var viewMOdel = new JRZLWTViewModel
            {

                SILSimulationTables = sILSimulationTables,

            }
             ;
            
            return View(viewMOdel);

        }
        public IActionResult HYIndexTOP()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            return View();

        }
        public IActionResult HYIndex24M()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            return View();

        }
        public IActionResult HYIndexWM()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            return View();

        }
        public IActionResult HYIndexQMC()

        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");
            return View();

        }
     
        public IActionResult HYIndexOTHER()

        {

            return View();

        }
        public IActionResult HYIndexMANAGER()

        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");

            return View();

        }

        public IActionResult TESTPAGES()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Index", "Home");

            var checklistsV91 = _context.DailyQualityIssueChecklistV91s.OrderBy(c => c.ID).ToList();

            var viewModel = new JRZLWTViewModel
            {
              
                ChecklistV91s = checklistsV91,
                AdditionalInfo = "即日质量问题清单",
                //other configration
                //JRZLWTV91Headers = HeaderMappingUtil.GetHeaderMapping<DailyQualityIssueChecklistV91Map>(),//添加映射


            };
            return View(viewModel);
        }
        public IActionResult HYIndexJRZLWT()
        {
            var checklists = _context.DailyQualityIssueChecklists
                .OrderBy(c => c.ID) // 按照ID排序
                .ToList();
            var checklistsV91 = _context.DailyQualityIssueChecklistV91s.OrderBy(c => c.ID).ToList();
            var checklistsV91Queries = _context.DailyQualityIssueChecklistV91Queries.OrderBy(c => c.ID).ToList();
            var dailyServiceReviewForms = _context.DailyServiceReviewForms.OrderBy(c => c.ID).ToList();
            var dailyServiceReviewFormsQueries = _context.DailyServiceReviewFormQueries.OrderBy(c => c.ID).ToList();
            var viewModel = new JRZLWTViewModel
            {
                Checklists = checklists,
                DailyServiceReviewForms = dailyServiceReviewForms,
                DailyServiceReviewFormQueries = dailyServiceReviewFormsQueries,
                ChecklistV91s = checklistsV91,
                ChecklistV91Queries = checklistsV91Queries,
                AdditionalInfo = "即日质量问题清单",
                //other configration
                JRZLWTV91Headers = HeaderMappingUtil.GetHeaderMapping<DailyQualityIssueChecklistV91Map>(),//添加映射


            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

