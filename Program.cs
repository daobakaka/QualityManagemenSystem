using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebWinMVC.Data;

namespace WebWinMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<JRZLWTDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("JRZLWTConnection")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.LoginPath = "/Home/Index"; // 未登录用户将重定向到此路径
        options.Cookie.Expiration = null;
    });

            // 添加Session服务
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5); // 设置 Session 超时时间为 30 分钟
                options.Cookie.HttpOnly = true; // 使 cookie 只能通过 HTTP 访问
                options.Cookie.IsEssential = true; // 保证即使用户不同意 Cookie 也启用
                options.Cookie.HttpOnly = true;

                // options.Cookie.Expiration = null; // 这里不必使用如此，因为 session 是默认清空
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                Console.WriteLine("start!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                JRZLWTDbContextInitializer.Initialize(services);
                Console.WriteLine("end!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            // 启用Session
            //
            app.UseAuthentication();  // 确保启用了身份验证
            app.UseAuthorization();   // 确保启用了授权

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
