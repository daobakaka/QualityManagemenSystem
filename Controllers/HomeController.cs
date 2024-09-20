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
                // 先查找用户
                var user = _context.userAuthentications
                    .FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    Console.WriteLine($"用户 {user.Username} 存在，正在验证密码...");                  

                    // 验证密码
                    if (user.Password == model.Password) // 替换为哈希验证逻辑
                    {
                        Console.WriteLine("密码验证成功，登录成功。");
                        TempData["IsLoggedIn"] = true; // 登录成功
                        return RedirectToAction("HYIndexJRZLWTV91", "HYIndex");
                    }
                    else
                    {
                        Console.WriteLine("密码不正确。");
                      
                    }
                }
                else
                {
                    Console.WriteLine("用户名不存在。");
                   
                }
            }

            // 登录失败，重定向到 Index 页面
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
