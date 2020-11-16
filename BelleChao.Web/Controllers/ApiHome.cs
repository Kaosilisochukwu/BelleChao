using BelleChao.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class ApiHome : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepo;

        public ApiHome(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }
        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantRepo.GetRestaurants();
            return Ok(restaurants);
        }
    }
}
