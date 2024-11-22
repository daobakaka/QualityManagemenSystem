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

            // ע�� DQIUpdateService ����,���������������п��Դ�������
            builder.Services.AddScoped<DQIUpdateController>();
            builder.Services.AddScoped<AutomaticDataChangeController>();
            //--
            builder.Services.AddDbContext<JRZLWTDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("JRZLWTConnection")));
            //��Ӹ��ְ�ȫ��֤----JWT ��ȫ��֤
            //var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            //var secretKey = jwtSettings["SecretKey"];
            //// ������֤
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
            //-- JWT ��ȫ��֤
            //�����֤ cookeis
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Home/Index"; // δ��¼�û����ض��򵽴�·��
                options.Cookie.Expiration = null;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // ��ͨ�� HTTPS ����
                options.Cookie.SameSite = SameSiteMode.Strict; // ��ֹ CSRF ����

            });
            // ���Session����
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10); // ���� Session ��ʱʱ��Ϊ 30 ����
                options.Cookie.HttpOnly = true; // ʹ cookie ֻ��ͨ�� HTTP ����
                options.Cookie.IsEssential = true; // ��֤��ʹ�û���ͬ�� Cookie Ҳ����
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // ��ͨ�� HTTPS ����
                options.Cookie.SameSite = SameSiteMode.Strict; // ��ֹ CSRF ����


                // options.Cookie.Expiration = null; // ���ﲻ��ʹ����ˣ���Ϊ session ��Ĭ�����
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
            // ����Session
            //
            app.UseAuthentication();  // ȷ�������������֤
            app.UseAuthorization();   // ȷ����������Ȩ

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
