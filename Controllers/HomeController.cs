using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebWinMVC.Data;
using WebWinMVC.Models;

namespace WebWinMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JRZLWTDbContext _context;
        public HomeController(ILogger<HomeController> logger, JRZLWTDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login(UserAuthentication model)
        {
            if (ModelState.IsValid)
            {
                // �Ȳ����û�
                var user = _context.userAuthentications
                    .FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    Console.WriteLine($"�û� {user.Username} ���ڣ�������֤����...");                  

                    // ��֤����
                    if (user.Password == model.Password) // �滻Ϊ��ϣ��֤�߼�
                    {
                        Console.WriteLine("������֤�ɹ�����¼�ɹ���");
                        TempData["IsLoggedIn"] = true; // ��¼�ɹ�
                        return RedirectToAction("HYIndexJRZLWTV91", "HYIndex");
                    }
                    else
                    {
                        Console.WriteLine("���벻��ȷ��");
                      
                    }
                }
                else
                {
                    Console.WriteLine("�û��������ڡ�");
                   
                }
            }

            // ��¼ʧ�ܣ��ض��� Index ҳ��
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
