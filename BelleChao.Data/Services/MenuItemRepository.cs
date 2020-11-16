using BelleChao.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<bool> AddmenuItem(MenuItem menuItem)
        {
            var addResult = await _context.MenuItems.AddAsync(menuItem);
            if(addResult.State == EntityState.Added)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletMenuItem(string id)
        {
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.Id == id);
            if (menuItem == null)
                return false;
            var deleteResult = _context.MenuItems.Remove(menuItem);
            if(deleteResult.State == EntityState.Deleted)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditMenuItem(MenuItem item)
        {
            var menuItemToEdit = await _context.MenuItems.FirstOrDefaultAsync(MenuItem => MenuItem.Id == item.Id);
            if (menuItemToEdit == null)
            {
                return false;
            }
            menuItemToEdit.Name = item.Name;
            menuItemToEdit.PhotoUrl = item.PhotoUrl;
            menuItemToEdit.UnitPrice = item.UnitPrice;
            menuItemToEdit.Description = item.Description;
            var editResult =  _context.Update(menuItemToEdit);
            if(editResult.State == EntityState.Modified)
            {
                return true;
            }
            return false;
        }

        public async Task<MenuItem> GetMenuItemById(string id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(menuItem => menuItem.Id == id);
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems(string restaurantId)
        {
            return await _context.MenuItems.ToListAsync();
        }
    }
}
