using BelleChao.Data.Models;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "vendor")]
    public class ApiMenuItem : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public ApiMenuItem(IMenuItemRepository menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }

        public async Task<IActionResult> AddmenuItem(MenuItem menuItem)
        {
            try
            {
                var addItemResult = await _menuItemRepo.AddmenuItem(menuItem);
                if (addItemResult == null)
                {
                    return BadRequest();
                }
                return Ok(addItemResult);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> DeletMenuItem(string id)
        {
            try
            {
                var deletionResult = await _menuItemRepo.DeletMenuItem(id);
                if (!deletionResult)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> EditMenuItem(MenuItem item)
        {
            try
            {
                var menuItemEdited = await _menuItemRepo.EditMenuItem(item);
                if(menuItemEdited == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> GetMenuItemById(string id)
        {
            try
            {
                var menuItem = await _menuItemRepo.GetMenuItemById(id);
                if(menuItem == null)
                {
                    return BadRequest();
                }
                return Ok(menuItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> GetMenuItems()
        {
            try
            {
                var menuItems = await _menuItemRepo.GetMenuItems();
                if(menuItems == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IActionResult> GetMenuItems(string restaurantId)
        {
            try
            {
                var menuItems = await _menuItemRepo.GetMenuItemsByRestaurantId(restaurantId);
                if(menuItems == null)
                {
                    return BadRequest();
                }
                return Ok(menuItems);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
