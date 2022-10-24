using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authorization_ASP.Net_Core.JwtBearer_5._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "zenia"),
                new Claim(JwtRegisteredClaimNames.Email, "zenia@mail.ru")
            };

            var token = new JwtSecurityToken();

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
