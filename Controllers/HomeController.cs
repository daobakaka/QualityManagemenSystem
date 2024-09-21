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
                // �Ȳ����û�
                var user = _context.userAuthentications
                    .FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    Console.WriteLine($"�û� {user.Username} ���ڣ�������֤����...");                  

                    // ��֤����
                    if (user.Password == model.Password) // �滻Ϊ��ϣ��֤�߼�
                    {
                        HttpContext.Session.SetString("Username", user.Username??"NIL");
                        HttpContext.Session.SetString("Name", user.Name ?? "NIL");
                        HttpContext.Session.SetString("Role", user.Role ?? "NIL");
                        HttpContext.Session.SetString("Group", user.Group ?? "NIL");
                        HttpContext.Session.SetString("Phone", user.Phone ?? "NIL");
                        Console.WriteLine($"������֤�ɹ�����¼�ɹ���{user.Username}+{HttpContext.Session.GetString("Username")}+{HttpContext.Session.GetString("Name")}" +
                              $"+{HttpContext.Session.GetString("Role")}+{HttpContext.Session.GetString("Group")}+{HttpContext.Session.GetString("Phone")}");

                        TempData["IsLoggedIn"] = true; // ��¼�ɹ�
                        HttpContext.Session.SetString("IsLoggedIn", "true"); // ��¼�ɹ������� IsLoggedIn Ϊ true

                        // ��������֤�� Cookie ��

                       
                        var claims = new List<Claim>
                                {
                              new Claim(ClaimTypes.Name, user.Username),
                                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = false // ���ֵ�¼״̬
                        };

                        // ��¼�û������� Cookie
                         await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                       // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
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
