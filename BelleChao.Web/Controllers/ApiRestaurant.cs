using AutoMapper;
using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Data.Services;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api/restaurants")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiRestaurant : ControllerBase
    {
        private readonly IRestaurantRepository _restrurantRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiRestaurant(IRestaurantRepository restrurantRepo, CloudinaryConfig cloudinaryConfig, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _restrurantRepo = restrurantRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RestaurantToPost model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = _mapper.Map<RestaurantToPost, Restaurant>(model);
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                restaurant.OwnerId = userId;
                
                var registerRestaurantResult = await _restrurantRepo.AddRestaurant(restaurant);
                if(registerRestaurantResult != "Not sucessful")
                {
                    return Ok(registerRestaurantResult);
                }
                return BadRequest(registerRestaurantResult);
            }
            return BadRequest();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRestaurants()
        {
            try
            {
                var restaurants = await _restrurantRepo.GetRestaurants();
                return Ok(restaurants);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("{Id}")]
        public async Task<IActionResult> GetRestaurantById(string Id)
        {
            try
            { 
                var restaurant = await _restrurantRepo.GetRestaurantById(Id);
                if(restaurant == null)
                {
                    return BadRequest();
                }
                return Ok(restaurant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("{restaurantId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurant(string restaurantId)
        {
            try
            {
                var deletionResult = await _restrurantRepo.DeleteRestaurant(restaurantId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("{restaurantId}/approve")]
        [HttpPatch]
        public async Task<IActionResult> ApproveRestaurant(string restaurantId)
        {
            try
            {
                var approvalResult = await _restrurantRepo.ApproveRestaurant(restaurantId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [Route("{restaurantId}/disapprove")]
        [HttpPatch]
        public async Task<IActionResult> DisapproveRestaurant(string restaurantId)
        {
            try
            {
                var approvalResult = await _restrurantRepo.DisapproveRestaurant(restaurantId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [Route("{restaurantId}/update")]
        [HttpPatch]
        public async Task<IActionResult> UpdateRestaurant(string restaurantId, RestaurantToUpdateDTO model)
        {
            try
            {
                var restaurantEditResponse = await _restrurantRepo.EditRestaurant(restaurantId, model);
                if (restaurantEditResponse > 0)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("{restaurantId}/deleteAvatar")]
        [HttpPatch]
        public async Task<IActionResult> DeleteAvatar(string restaurantId)
        {
            try
            {
                var avatarDeletionResult = await _restrurantRepo.DeleteAvatar(restaurantId);
                if (avatarDeletionResult > 0)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("{restaurantId}/updateAvatar")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAvatar(string restaurantId, string photoUrl)
        {
            try
            {
                var avatarDeletionResult = await _restrurantRepo.UpdateAvatar(restaurantId, photoUrl);
                if (avatarDeletionResult)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
