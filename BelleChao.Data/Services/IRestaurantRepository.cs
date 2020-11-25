using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IRestaurantRepository
    {
        public Task<bool> AddRestaurant(RestaurantToRegisterDTO restaurant);

        public Task<bool> DeleteRestaurant(string restaurantId);

        public Task<bool> EditRestaurant(Restaurant restaurant);

        public Task<Restaurant> GetRestaurantById(string restaurantId);

        public Task<IEnumerable<Restaurant>> GetRestaurants();

    }
}
