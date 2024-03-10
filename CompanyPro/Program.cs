using CompanyPro.Filtters;
using CompanyPro.Models;
using CompanyPro.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. (register service inside ioc container)
            //Build in service already registered (90)

            //Built in service need register
            //builder.Services.AddControllersWithViews(options=>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//session abort
            });
            builder.Services.AddDbContext<ITIContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            
            //Register Identity Service (userManager -roleMnager- SigninManager)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                    options =>
                    {
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 5;
                    }).AddEntityFrameworkStores<ITIContext>();

            //register your custom service
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
















            //---------------------------------
            var app = builder.Build();
            //---------------------------------
            #region Custom Middleware
            //inline Middlew
            //app.Use(async (httpcontext, next) => {
            //    await httpcontext.Response.WriteAsync("1- Middleware1 \n");
            //    //call next    
            //    await next.Invoke();//--------------
            

            //});//End Middleware
            //app.Use(async (httpcontext, next) =>
            //{
            //    await httpcontext.Response.WriteAsync("2- Middleware2 \n");
            //    //call next
            //    await next.Invoke();//------------

            //    await httpcontext.Response.WriteAsync("2-2 Middleware2-2 \n");

            //});
            //app.Run(async (httpcontext) => { 
            //    await httpcontext.Response.WriteAsync("3- Terminate \n");

            //});
            //app.Use(async (httpcontext, next) => {
            //    await httpcontext.Response.WriteAsync("3- Middleware3 \n");
            //    //call next
            //    await next.Invoke();
            //});
            #endregion

            #region Built in middlewWare
            // Configure the HTTP request pipeline. Middleware Day2
            if (!app.Environment.IsDevelopment())//lanuch setting -- windows
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//handel req wwwroot
            //options
            //(SEcurity)
            app.UseRouting();//employee/all (controller,action)

            app.UseSession();
            
            app.UseAuthentication();//default
            
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    "Method1Route",
            //    "M1/{name}/{age:int:range(10,30)}/{color?}",
            //    new { controller="Route" ,action="Method1"}
            //    );
            //app.MapControllerRoute(
            //  "Method2Route",
            //  "M2",
            //  new { controller = "Route", action = "Method2" }
            //  );

            app.MapControllerRoute(
                "Method1Route",
                "M/{action=Method2}/{id?}",
                new { controller = "Route" }
                );
            //app.MapControllerRoute(
            //    "Method2Route",
            //    "{Controller=Route}/{action=Method2}/{id?}"
            //    );


            //NAmeing Convination Route
            //Staff (Plan + Execute)
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=Index}/{id?}");
            #endregion

            app.Run();//not middleware
        }
    }
}
