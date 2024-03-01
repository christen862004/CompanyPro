namespace CompanyPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//session abort
            });
            
            var app = builder.Build();

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
            app.UseRouting();//employee/all (controller,action)

            app.UseSession();
            //app.UseAuthorization();//

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=Index}/{id?}");
            //

            #endregion

            app.Run();//not middleware
        }
    }
}
