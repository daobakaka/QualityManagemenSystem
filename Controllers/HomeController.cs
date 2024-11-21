using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebWinMVC.Data;
using WebWinMVC.Models;
using BCrypt.Net; // ȷ������ BCrypt.Net �����ռ�
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
                    // �����û�
                    var user = _context.userAuthentications.FirstOrDefault(u => u.Username == model.Username);

                    if (user != null)
                    {
                        _logger.LogInformation($"�û� {user.Username} ���ڣ�������֤����...");

                        bool isPasswordValid = false;

                        // ��������Ƿ�Ϊ�ѹ�ϣ�ĸ�ʽ
                        if (user.Password.StartsWith("$2a$") || user.Password.StartsWith("$2b$") || user.Password.StartsWith("$2y$"))
                        {
                            // �Ѿ���ϣ�����룬ʹ�� BCrypt ��֤
                            isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                        }
                        else
                        {
                            // �������룬ֱ�ӱȽϣ����Ƽ���
                            isPasswordValid = (user.Password == model.Password);
                            if (isPasswordValid)
                            {
                                // ���������֤ͨ����������ϣ���������ݿ�
                                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                                user.Password = hashedPassword;
                                _context.Update(user);
                                await _context.SaveChangesAsync();
                                _logger.LogInformation($"�û� {user.Username} �������ѱ���ϣ���¡�");
                            }
                        }

                        if (isPasswordValid)
                        {
                            // ���� Session ����
                            HttpContext.Session.SetString("Username", user.Username ?? "NIL");
                            HttpContext.Session.SetString("Name", user.Name ?? "NIL");
                            HttpContext.Session.SetString("Role", user.Role ?? "NIL");
                            HttpContext.Session.SetString("Group", user.Group ?? "NIL");
                            HttpContext.Session.SetString("Phone", user.Phone ?? "NIL");

                            _logger.LogInformation($"������֤�ɹ����û� {user.Username} �ѵ�¼��");

                            TempData["IsLoggedIn"] = true; // ��¼�ɹ�
                            HttpContext.Session.SetString("IsLoggedIn", "true"); // ���� IsLoggedIn Ϊ true

                            // ��������֤�� Cookie ��
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Username ?? "None"),
                                // ������Ҫ��Ӹ��� Claims
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties
                            {
                                IsPersistent = false // �����ֵ�¼״̬
                            };

                            // ��¼�û������� Cookie
                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties
                            );

                            return RedirectToAction("HYIndexJRZLWTV91", "HYIndex");
                        }
                        else
                        {
                            _logger.LogWarning($"�û� {user.Username} ��������֤ʧ�ܡ�");
                            ModelState.AddModelError("", "���벻��ȷ��");
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"�û��� {model.Username} �����ڡ�");
                        ModelState.AddModelError("", "�û��������ڡ�");
                    }
                }
                catch (SaltParseException ex)
                {
                    _logger.LogError($"������֤ʱ��������: {ex.Message}");
                    ModelState.AddModelError("", "������֤ʧ�ܡ�����ϵ����Ա��");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"��¼�����з����쳣: {ex.Message}");
                    ModelState.AddModelError("", "��¼�����з����������Ժ����ԡ�");
                }
            }

            // ��¼ʧ�ܣ�������ʾ��¼ҳ�沢��ʾ����
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
