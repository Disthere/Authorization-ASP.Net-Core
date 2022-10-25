using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Identity.IdentityServer.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SiteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> GetOrders()
        {
            var ordersClient = _httpClientFactory.CreateClient();

            var responce = await ordersClient.GetAsync("https://localhost:7001/site/GetSecrets");

            var message = await responce.Content.ReadAsStringAsync();

            ViewBag.Message = message;

            return View();
        }

    }
}
