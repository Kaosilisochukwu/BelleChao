using BelleChao.Data.Models;
using BelleChao.Data.Services;
using BelleChao.Web.Models;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Request _requestMaker;

        public HomeController(ILogger<HomeController> logger, IRestaurantRepository restaurantRepo)
        {
            _requestMaker = new Request(new HttpContextAccessor());
        }

        public async Task<IActionResult> Index()
        {
            var response = await _requestMaker.GetMethod("/api/home");
            var dataString = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(dataString);
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
