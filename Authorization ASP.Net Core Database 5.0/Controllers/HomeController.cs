﻿using Microsoft.AspNetCore.Mvc;

namespace Authorization_ASP.Net_Core.Database_5._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
