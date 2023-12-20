using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Pustokdb>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            }).AddIdentity<AppUser, IdentityRole>(opt =>
{
                opt.SignIn.RequireConfirmedEmail = false;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789._";
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<Pustokdb>(); ;
			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = new PathString("/Auth/Login");
				options.LogoutPath = new PathString("/Auth/Logout");
				//options.AccessDeniedPath = new PathString("/Home/AccessDenied");

				options.Cookie = new()
				{
					Name = "IdentityCookie",
					HttpOnly = true,
					SameSite = SameSiteMode.Lax,
					SecurePolicy = CookieSecurePolicy.Always
				};
				options.SlidingExpiration = true;
				options.ExpireTimeSpan = TimeSpan.FromDays(30);
			});
			builder.Services.AddSession();

			builder.Services.AddScoped<LayoutService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                     name: "Admin",
                     pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}