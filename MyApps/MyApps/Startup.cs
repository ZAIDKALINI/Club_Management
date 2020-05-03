using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApps.Models;

namespace MyApps
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddDbContextPool<App_Context>(options=>options.UseSqlServer(Configuration.GetConnectionString("Default")).EnableSensitiveDataLogging());
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<App_Context>();
           
            services.AddControllersWithViews();
            services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages().AddNewtonsoftJson();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment  env,  UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
         
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            MyIdentityDataInitializer.SeedData(userManager, roleManager);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=portfolio}/{action=Index}/{id?}");
            });
        }
    }
    public static class MyIdentityDataInitializer
    {
        public static void SeedData
    (UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
          
        }

        public static void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            

            if (userManager.FindByNameAsync
        ("wwwroot").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "wwwroot";
                user.Email = "wwwroot@email.com";
                

                IdentityResult result = userManager.CreateAsync
                (user, "KALINI1997kalini@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "SuperManager").Wait();
                }
            }
        }

        public static void SeedRoles
    (RoleManager<IdentityRole> roleManager)
        {
          if (!roleManager.RoleExistsAsync ("SuperManager").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "SuperManager";
                  IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
