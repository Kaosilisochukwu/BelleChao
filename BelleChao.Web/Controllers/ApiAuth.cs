using AutoMapper;
using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Data.Services;
using BelleChao.Web.Utilities;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class ApiAuth : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApiAuth(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
                                            IRestaurantRepository restaurantRepo,
                                            IConfiguration configuration, IMapper mapper)
        {
            _restaurantRepo = restaurantRepo;
            _configuration = configuration;
            _mapper = mapper;
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
        public  async Task<IActionResult> Register(UserTOPostDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserTOPostDTO, ApplicationUser>(model);
                var creationResult = await _userManager.CreateAsync(user, model.Password);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserToLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.FindByEmailAsync(model.Email);
                var signinResult = await _signInManager.PasswordSignInAsync(applicationUser, model.Password, model.IsPersistent, false);
                if (signinResult.Succeeded)
                {
                    var roles = (await _userManager.GetRolesAsync(applicationUser)).ToList();
                    var token = TokenConfigurations.GenerateToken(applicationUser, _configuration, roles);
                    return Ok(token);
                }
            }
            return BadRequest();
        }
    }
}
