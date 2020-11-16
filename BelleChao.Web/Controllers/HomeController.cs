using BelleChao.Data.Models;
using BelleChao.Data.Services;
using BelleChao.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantRepository _restaurantRepo;

        public HomeController(ILogger<HomeController> logger, IRestaurantRepository restaurantRepo)
        {

            _logger = logger;
            _restaurantRepo = restaurantRepo;
        }

        public async Task<IActionResult> Index()
        {
            var baseUrl = HttpContext.Request.Host.ToUriComponent();
            var url = $"http://{baseUrl}/api/home";
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage();
            message.RequestUri = new Uri(url);
            var response = await client.SendAsync(message);
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
