using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddRestaurant(RestaurantToRegisterDTO restaurant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRestaurant(string restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Task<Restaurant> GetRestaurantById(string restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return restaurants;
        }

    }
}
