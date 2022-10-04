using Microsoft.AspNetCore.Mvc;

namespace Authorization_ASP.Net_Core.Basics_5._0.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
