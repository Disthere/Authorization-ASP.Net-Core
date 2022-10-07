using Authorization_ASP.Net_Core_Database_5._0.Data;
using Authorization_ASP.Net_Core_Database_5._0.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization_ASP.Net_Core_Database_5._0
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseInMemoryDatabase("MEMORY");
            })
                .AddIdentity<ApplicationUser, ApplicationRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 3;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddAuthentication("Cookie")
            //    .AddCookie("Cookie", config =>
            //    {
            //        config.LoginPath = "/Admin/Login";
            //        config.AccessDeniedPath = "/Home/AccessDenied";
            //    });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Admin/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", builder =>
                {
                    //builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                    builder.RequireClaim(ClaimTypes.Role, "Administrator");
                });

                options.AddPolicy("Manager", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager"));
                    //builder.RequireClaim(ClaimTypes.Role, "Manager");
                });

                options.AddPolicy("Manager", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager")
                    || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                });

            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
