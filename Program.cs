using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebWinMVC.Controllers;
using WebWinMVC.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebWinMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 注册 DQIUpdateService 服务,用于在其他控制中可以处理依赖
            builder.Services.AddScoped<DQIUpdateController>();
            builder.Services.AddScoped<AutomaticDataChangeController>();
            //--
            builder.Services.AddDbContext<JRZLWTDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("JRZLWTConnection")));
            //添加各种安全认证----JWT 安全认证
            //var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            //var secretKey = jwtSettings["SecretKey"];
            //// 配置认证
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = jwtSettings["Issuer"],
            //        ValidAudience = jwtSettings["Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            //    };
            //});
            //-- JWT 安全认证
            //添加认证 cookeis
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Home/Index"; // 未登录用户将重定向到此路径
                options.Cookie.Expiration = null;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // 仅通过 HTTPS 发送
                options.Cookie.SameSite = SameSiteMode.Strict; // 防止 CSRF 攻击

            });
            // 添加Session服务
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10); // 设置 Session 超时时间为 30 分钟
                options.Cookie.HttpOnly = true; // 使 cookie 只能通过 HTTP 访问
                options.Cookie.IsEssential = true; // 保证即使用户不同意 Cookie 也启用
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // 仅通过 HTTPS 发送
                options.Cookie.SameSite = SameSiteMode.Strict; // 防止 CSRF 攻击


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
