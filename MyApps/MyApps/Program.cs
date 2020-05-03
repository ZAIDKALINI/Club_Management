using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // var host = new WebHostBuilder().Build();
           var webhost= CreateHostBuilder(args).Build();
            RunMigrations(webhost);
          SeedData(webhost);
            webhost.Run();
        }

        private static void SeedData(IHost webhost)
        {
          

            using (var scope = webhost.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var userManager = serviceProvider.
        GetRequiredService<UserManager<ApplicationUser>>();

                    var roleManager = serviceProvider.
        GetRequiredService<RoleManager<IdentityRole>>();

                    MyIdentityDataInitializer.SeedData
                            (userManager, roleManager);
                }
                catch
                {

                }
            }
        }

        private static void RunMigrations(IHost webhost)
        {
            using (var scope=webhost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<App_Context>();
                db.Database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
