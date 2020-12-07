using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IMenuItemRepository
    {
        Task<string> AddmenuItem(MenuItem menuItem);

        Task<int> DeletMenuItem(string id);

        Task<string> EditMenuItem(MenuItem item);

        Task<MenuItem> GetMenuItemById(string id);

        Task<IEnumerable<MenuItem>> GetMenuItems();
        Task<int> DeleteAllRestaurantMenuItems(string restaurantId);
        Task<IEnumerable<MenuItem>> GetMenuItemsByRestaurantId(string restaurantId);
    }
}
