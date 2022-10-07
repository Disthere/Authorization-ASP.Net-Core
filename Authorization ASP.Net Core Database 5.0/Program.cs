using Authorization_ASP.Net_Core_Database_5._0.Data;
using Authorization_ASP.Net_Core_Database_5._0.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization_ASP.Net_Core_Database_5._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                Databaseinitializer.Init(scope.ServiceProvider);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class Databaseinitializer
    {
        public static async void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName = "User",
                //Password = "123",
                LastName = "LastName",
                FirstName = "FirstName"
            };

           var result = userManager.CreateAsync(user, "123").GetAwaiter().GetResult();

            if (result.Succeeded)
            {
               userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
            }

            //context.Users.Add(user);
            //context.SaveChanges();
        }
    }
}
