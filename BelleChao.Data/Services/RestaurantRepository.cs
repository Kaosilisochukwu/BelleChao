using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;
        private readonly IMenuItemRepository _menuItemsRepo;

        public RestaurantRepository(AppDbContext context, IMenuItemRepository menuItemsRepo)
        {
            _context = context;
            _menuItemsRepo = menuItemsRepo;
        }
        public async Task<string> AddRestaurant(Restaurant restaurant)
        {
            restaurant.Id = generateId();
            var restaurantAdditionResult = await _context.Restaurants.AddAsync(restaurant);
            if(restaurantAdditionResult.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return restaurant.Id;
            }
            return "Not sucessful";
        }

        public async Task<int> ApproveRestaurant(string restaurantId)
        {
            var updateCount = 0;
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == restaurantId);
            restaurant.IsApproved = true;
            var updateResult = _context.Restaurants.Update(restaurant);
            if(updateResult.State == EntityState.Modified)
            {
                updateCount = await _context.SaveChangesAsync();
            }
            return updateCount;
        }

        public async Task<int> DeleteAvatar(string restaurantId)
        {
            var updateCount = 0;
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == restaurantId);
            restaurant.PhotoPublicId = null;
            restaurant.PhotoUrl = null;
            var updateResult = _context.Restaurants.Update(restaurant);
            if (updateResult.State == EntityState.Deleted)
            {
                updateCount = await _context.SaveChangesAsync();
            }
            return updateCount;
        }

        public async Task<int> DeleteRestaurant(string restaurantId)
        {
            var updateCount = 0;
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == restaurantId);
            var updateResult = _context.Restaurants.Remove(restaurant);
            if (updateResult.State == EntityState.Deleted)
            {
                await _menuItemsRepo.DeleteAllRestaurantMenuItems(restaurantId);
                updateCount = await _context.SaveChangesAsync();
            }
            return updateCount;
        }

        public async Task<int> DisapproveRestaurant(string restaurantId)
        {
            int updateResult = 0;
            var restaurant = _context.Restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);
            if (restaurant != null)
            {
                restaurant.IsApproved = false;
                updateResult = await _context.SaveChangesAsync();
            }
            return updateResult;
        }

        public async Task<int> EditRestaurant(string restaurantId, RestaurantToUpdateDTO model)
        {
            int updateResult = 0;
            var restaurant = _context.Restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);
            if (restaurant != null)
            {
                restaurant.Name = model.Name;
                restaurant.PhoneNumber = model.PhoneNumber;
                restaurant.Email = model.Email;
                restaurant.Address = model.Address;
                restaurant.City = model.City;
                restaurant.State = model.State;
                updateResult = await _context.SaveChangesAsync();
            }
            return updateResult;
        }

        public async Task<Restaurant> GetRestaurantById(string restaurantId)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == restaurantId);
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<int> UpdateAvatar(string restaurantId, AvatarToUpdateDTO avatarDetails)
        {
            var rowsChanged = 0;
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(restaurant => restaurant.Id == restaurantId);
            restaurant.PhotoUrl = avatarDetails.PhotoUrl;
            restaurant.PhotoPublicId = avatarDetails.PhotoPublicId;
            var updateResult = _context.Update(restaurant);
            if(updateResult.State == EntityState.Modified)
            {
                rowsChanged = await _context.SaveChangesAsync();
            }
            return rowsChanged;
        }

        string generateId()
        {
            var id = Guid.NewGuid().ToString();
            while (_context.Restaurants.Where(item => item.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
    }
}
