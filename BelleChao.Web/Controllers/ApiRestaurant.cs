using BelleChao.Data.DTOs;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Route("api/restaurants")]
    public class ApiRestaurant : ControllerBase
    {
        private readonly IRestaurantRepository _restrurantRepo;

        public ApiRestaurant(IRestaurantRepository restrurantRepo)
        {
            _restrurantRepo = restrurantRepo;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RestaurantToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                _restrurantRepo.AddRestaurant(model);
            }
            return Ok();
        }
        
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
                var restaurantToEdit = await _restrurantRepo.EditRestaurant(restaurantId, model);
                if (restaurantToEdit)
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

        [Route("{restaurantId}/updateAvatar")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAvatar(string restaurantId, IFormFile photo)
        {
            try
            {
                var avatarDeletionResult = await _restrurantRepo.UpdateAvatar(restaurantId, photo);
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
