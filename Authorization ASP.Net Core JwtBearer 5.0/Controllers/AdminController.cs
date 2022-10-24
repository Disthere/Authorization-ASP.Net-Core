using Authorization_ASP.Net_Core.JwtBearer_5._0.Views;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization_ASP.Net_Core.JwtBearer_5._0.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
             

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await _context.Users
            //    .SingleOrDefaultAsync(x => x.UserName == model.UserName);
            //     //&& x.Password == model.Password);

           

            return View(model);
            


        }

        public async Task<IActionResult> LogOffAsync()
        {
            //HttpContext.SignOutAsync("Cookie");

            //await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }

}
