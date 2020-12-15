using AutoMapper;
using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IMapper _mapper;
        private readonly HttpContextAccessor _httpContextAccessor;
        private readonly Request _requestMaker;

        public RestaurantController(IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper, HttpContextAccessor httpContextAccessor)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _requestMaker = new Request(httpContextAccessor);
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RestaurantToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {

                var managePhoto = new CloudinaryConfig(_cloudinaryConfig);
                var uploadResult = await managePhoto.UploadPhoto(model.Photo);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var restaurant = _mapper.Map<RestaurantToRegisterDTO, RestaurantToPost>(model);
                    restaurant.PhotoUrl = uploadResult.Url.ToString();
                    restaurant.PhotoPublicId = uploadResult.PublicId;
                    var response = await _requestMaker.PostForm($"api/restaurants/register", restaurant);
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var responseModel = JsonSerializer.Deserialize<IdentityResult>(json);
                        return View(responseModel);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRestaurant(string restaurantId)
        {
            var response = await _requestMaker.UpdateCell($"api/restaurants/{restaurantId}/approve");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var messsage = await response.Content.ReadAsStringAsync();
                return View(messsage);
            }
            return View("Unable to Update Restaurant Status");
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteAvatar(string restaurantId)
        {
            var deletionResult = await _requestMaker.UpdateCell($"api/restaurants/{restaurantId}/deleteAvatar");
            if(deletionResult.StatusCode == HttpStatusCode.OK)
            {
                return View();
            }
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurant(string restaurantId)
        {
            var deletionResult = await _requestMaker.Delete($"api/restaurants/{restaurantId}");
            if(deletionResult.StatusCode == HttpStatusCode.OK)
            {
                return View();
            }
            return View();
        }

        [HttpPatch]
        public async Task<IActionResult> DisapproveRestaurant(string restaurantId)
        {
            var updateResult = await _requestMaker.UpdateCell($"api/restaurants/disapprove");
            if(updateResult.StatusCode == HttpStatusCode.OK)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditRestaurant(string restaurantId, RestaurantToUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _requestMaker.UpdateForm($"api/restaurants/{restaurantId}", model);
                if(updateResult.StatusCode == HttpStatusCode.OK)
                {
                    return View();
                }
                return View();
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetRestaurantById(string restaurantId)
        {
            var getResult = await _requestMaker.GetMethod($"api/restaurants/{restaurantId}");
            if (getResult.StatusCode == HttpStatusCode.OK)
            {
                var responseString = await getResult.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<Restaurant>(responseString);
                return View(restaurant);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var getResult = await _requestMaker.GetMethod($"api/restaurants");
            if (getResult.StatusCode == HttpStatusCode.OK)
            {
                var responseString = await getResult.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(responseString);
                return View(restaurant);
            }
            return View();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAvatar(string restaurantId, AvatarToUpdateDTO avatarDetails)
        {
            var getResult = await _requestMaker.UpdateForm($"api/restaurants/{restaurantId}/updateAvatar", avatarDetails);
            if (getResult.StatusCode == HttpStatusCode.OK)
            {
                var responseString = await getResult.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(responseString);
                return View(restaurant);
            }
            return View();
        }
    }
}
