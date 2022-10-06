using Authorization_ASP.Net_Core.Database_5._0.Views;
using Authorization_ASP.Net_Core_Database_5._0.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorization_ASP.Net_Core.Database_5._0.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context) =>
        _context = context;

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

            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == model.UserName
                 && x.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model); 
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                //new Claim(ClaimTypes.Role, "Manager")
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect(model.ReturnUrl);
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }

}
