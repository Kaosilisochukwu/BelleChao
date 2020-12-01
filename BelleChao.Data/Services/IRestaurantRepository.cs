using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IRestaurantRepository
    {
        public Task<bool> AddRestaurant(RestaurantToRegisterDTO restaurant);

        public Task<bool> DeleteRestaurant(string restaurantId);

        public Task<bool> EditRestaurant(string restaurantId, RestaurantToUpdateDTO model);

        public Task<Restaurant> GetRestaurantById(string restaurantId);

        public Task<IEnumerable<Restaurant>> GetRestaurants();

        public Task<bool> ApproveRestaurant(string restaurantId);

        public Task<bool> DisapproveRestaurant(string restaurantId);

        public Task<bool> DeleteAvatar(string restaurantId);

        public Task<bool> UpdateAvatar(string restaurantId, IFormFile photo);

    }
}
