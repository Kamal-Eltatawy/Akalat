using Aklat.Models;
using Aklat.Models.Context;
using Aklat.Reposatories.OrderProductRepo;
using Aklat.Reposatories.OrderRepo;
using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aklat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AklatContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
            builder.Services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AklatContext>();

            builder.Services.AddScoped<IOrderReposatory, OrderReposatory>();
            builder.Services.AddScoped<IProductReposatory, ProductReposatory>();
            builder.Services.AddScoped<ICategoryReposatory, CategoryReposatory>();
            builder.Services.AddScoped<IOrderProductcs, OrderProductRep>();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            var app = builder.Build();

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

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}