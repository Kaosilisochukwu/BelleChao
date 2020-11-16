using BelleChao.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IMenuItemRepository
    {
        public Task<bool> AddmenuItem(MenuItem menuItem);

        public Task<bool> DeletMenuItem(string id);

        public Task<bool> EditMenuItem(MenuItem item);

        public Task<MenuItem> GetMenuItemById(string id);

        public Task<IEnumerable<MenuItem>> GetMenuItems();

        public Task<IEnumerable<MenuItem>> GetMenuItems(string restaurantId);
    }
}
