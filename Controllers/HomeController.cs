using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebWinMVC.Data;
using WebWinMVC.Models;
using BCrypt.Net; // 确保引入 BCrypt.Net 命名空间
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthentication model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 查找用户
                    var user = _context.userAuthentications.FirstOrDefault(u => u.Username == model.Username);

                    if (user != null)
                    {
                        _logger.LogInformation($"用户 {user.Username} 存在，正在验证密码...");

                        bool isPasswordValid = false;

                        // 检查密码是否为已哈希的格式
                        if (user.Password.StartsWith("$2a$") || user.Password.StartsWith("$2b$") || user.Password.StartsWith("$2y$"))
                        {
                            // 已经哈希的密码，使用 BCrypt 验证
                            isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                        }
                        else
                        {
                            // 明文密码，直接比较（不推荐）
                            isPasswordValid = (user.Password == model.Password);
                            if (isPasswordValid)
                            {
                                // 如果密码验证通过，立即哈希并更新数据库
                                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                                user.Password = hashedPassword;
                                _context.Update(user);
                                await _context.SaveChangesAsync();
                                _logger.LogInformation($"用户 {user.Username} 的密码已被哈希更新。");
                            }
                        }

                        if (isPasswordValid)
                        {
                            // 设置 Session 数据
                            HttpContext.Session.SetString("Username", user.Username ?? "NIL");
                            HttpContext.Session.SetString("Name", user.Name ?? "NIL");
                            HttpContext.Session.SetString("Role", user.Role ?? "NIL");
                            HttpContext.Session.SetString("Group", user.Group ?? "NIL");
                            HttpContext.Session.SetString("Phone", user.Phone ?? "NIL");

                            _logger.LogInformation($"密码验证成功，用户 {user.Username} 已登录。");

                            TempData["IsLoggedIn"] = true; // 登录成功
                            HttpContext.Session.SetString("IsLoggedIn", "true"); // 设置 IsLoggedIn 为 true

                            // 添加身份认证到 Cookie 中
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Username ?? "None"),
                                // 根据需要添加更多 Claims
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties
                            {
                                IsPersistent = false // 不保持登录状态
                            };

                            // 登录用户，创建 Cookie
                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties
                            );

                            return RedirectToAction("HYIndexJRZLWTV91", "HYIndex");
                        }
                        else
                        {
                            _logger.LogWarning($"用户 {user.Username} 的密码验证失败。");
                            ModelState.AddModelError("", "密码不正确。");
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"用户名 {model.Username} 不存在。");
                        ModelState.AddModelError("", "用户名不存在。");
                    }
                }
                catch (SaltParseException ex)
                {
                    _logger.LogError($"密码验证时发生错误: {ex.Message}");
                    ModelState.AddModelError("", "密码验证失败。请联系管理员。");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"登录过程中发生异常: {ex.Message}");
                    ModelState.AddModelError("", "登录过程中发生错误。请稍后再试。");
                }
            }

            // 登录失败，重新显示登录页面并显示错误
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
