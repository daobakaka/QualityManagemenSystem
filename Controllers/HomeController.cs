using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
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

            HttpContext.Session.Clear();
           
            //ViewBag.Username = HttpContext.Session.GetString("Username");
            //ViewBag.Name = HttpContext.Session.GetString("Name");
            //ViewBag.Role = HttpContext.Session.GetString("Role");
            //ViewBag.Group = HttpContext.Session.GetString("Group");
            //ViewBag.Phone = HttpContext.Session.GetString("Phone");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Login(UserAuthentication model)
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
                        HttpContext.Session.SetString("Username", user.Username??"NIL");
                        HttpContext.Session.SetString("Name", user.Name ?? "NIL");
                        HttpContext.Session.SetString("Role", user.Role ?? "NIL");
                        HttpContext.Session.SetString("Group", user.Group ?? "NIL");
                        HttpContext.Session.SetString("Phone", user.Phone ?? "NIL");
                        Console.WriteLine($"密码验证成功，登录成功。{user.Username}+{HttpContext.Session.GetString("Username")}+{HttpContext.Session.GetString("Name")}" +
                              $"+{HttpContext.Session.GetString("Role")}+{HttpContext.Session.GetString("Group")}+{HttpContext.Session.GetString("Phone")}");

                        TempData["IsLoggedIn"] = true; // 登录成功
                        HttpContext.Session.SetString("IsLoggedIn", "true"); // 登录成功，设置 IsLoggedIn 为 true

                        // 添加身份认证到 Cookie 中

                       
                        var claims = new List<Claim>
                                {
                              new Claim(ClaimTypes.Name, user.Username),
                                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = false // 保持登录状态
                        };

                        // 登录用户，创建 Cookie
                         await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                       // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
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
