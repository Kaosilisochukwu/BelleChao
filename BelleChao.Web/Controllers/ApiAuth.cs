using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api")]
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

        [HttpPost]
        [Route("register")]
        public  IActionResult Register(UserToRegisterDTO model)
        {
            var mode = model;
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserToLoginDTO model)
        {
            var loginModel = ModelState;
            return Ok();
        }
    }
}
