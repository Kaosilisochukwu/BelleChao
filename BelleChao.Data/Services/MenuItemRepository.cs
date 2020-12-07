using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly AppDbContext _context;

        public MenuItemRepository(AppDbContext context)
        {
           _context = context;
        }
        public async Task<string> AddmenuItem(MenuItem menuItem)
        {
            menuItem.Id = await generateId();
            var addResult = await _context.MenuItems.AddAsync(menuItem);
            if(addResult.State == EntityState.Added)
            {
                _context.SaveChanges();
                return menuItem.Id;
            }
            return null;
        }

        public async Task<int> DeletMenuItem(string id)
        {
            int deleteCount = 0;
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.Id == id);
            if (menuItem == null)
                return deleteCount;
            var deleteResult = _context.MenuItems.Remove(menuItem);
            if(deleteResult.State == EntityState.Deleted)
            {
                deleteCount = await _context.SaveChangesAsync();
            }
            return deleteCount;
        }

        public async Task<string> EditMenuItem(MenuItem item)
        {
            var menuItemToEdit = await _context.MenuItems.FirstOrDefaultAsync(MenuItem => MenuItem.Id == item.Id);
            if (menuItemToEdit == null)
            {
                return "Item does not exist";
            }
            menuItemToEdit.Name = item.Name;
            menuItemToEdit.PhotoUrl = item.PhotoUrl;
            menuItemToEdit.UnitPrice = item.UnitPrice;
            menuItemToEdit.Description = item.Description;
            var editResult =  _context.Update(menuItemToEdit);
            if(editResult.State == EntityState.Modified)
            {
                return menuItemToEdit.Id;
            }
            return "Operation failed";
        }

        public async Task<MenuItem> GetMenuItemById(string id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.Id == id);
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByRestaurantId(string restaurantId)
        {
            return await _context.MenuItems.ToListAsync();
        }
        public async Task<int> DeleteAllRestaurantMenuItems(string restaurantId)
        {
            var menuItems = _context.MenuItems.Where(menuItem => menuItem.RestaurantId == restaurantId);
            _context.MenuItems.RemoveRange(menuItems);
            var deletionResult = await _context.SaveChangesAsync();
            return deletionResult;
        }
        string generateMenuItemId()
        {
            var id = Guid.NewGuid().ToString();
            while (_context.MenuItems.Where(item => item.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
        async Task<string> generateId()
        {
            var id = Guid.NewGuid().ToString();
            while (await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
    }
}
