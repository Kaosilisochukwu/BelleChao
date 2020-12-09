using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IRestaurantRepository
    {
        public Task<string> AddRestaurant(Restaurant restaurant);

        public Task<int> DeleteRestaurant(string restaurantId);

        public Task<int> EditRestaurant(string restaurantId, RestaurantToUpdateDTO model);

        public Task<Restaurant> GetRestaurantById(string restaurantId);

        public Task<IEnumerable<Restaurant>> GetRestaurants();

        public Task<int> ApproveRestaurant(string restaurantId);

        public Task<int> DisapproveRestaurant(string restaurantId);

        public Task<int> DeleteAvatar(string restaurantId);

        public Task<int> UpdateAvatar(string restaurantId, AvatarToUpdateDTO avatarDetails);

    }
}
