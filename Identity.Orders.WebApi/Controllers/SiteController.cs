using Microsoft.AspNetCore.Mvc;

namespace Identity.IdentityServer.WebApi.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public string GetSecrets()
        {
            return "Secret string from Orders.WebApi";
        }
    }
}
