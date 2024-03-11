using CatalogFooball.Database;
using CatalogFooball.Services.SignalR;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace CatalogFooball
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddSignalR();

            builder.Services.AddDbContext<FootballDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapHub<PlayerHub>("/Player/Hub", options =>
            {
                options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Player}/{action=Index}/{id?}",
                defaults: new { controller = "Player", action = "Index" });


            app.Run();
        }
    }
}
