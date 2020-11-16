using BelleChao.Data.Models;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class ApiAuth : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApiAuth(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
            _userManager = userManager;
           _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantRepo.GetRestaurants();
            return Ok(restaurants);
        }
    }
}
