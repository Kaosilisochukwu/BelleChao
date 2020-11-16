using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BelleChao.Data.Services
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public string ShoppingCartId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(MenuItem menuItem)
        {
            var orderDetail = OrderDetails.FirstOrDefault(order => order.MenuItemId == menuItem.Id);
            
            if(orderDetail == null)
            {
                orderDetail = new OrderDetail
                {
                    Id = GetId(),
                    MenuItemId = menuItem.Id,
                    Quantity = 1,
                    Price = menuItem.UnitPrice,
                    OrderId = ShoppingCartId
                };
                OrderDetails.Add(orderDetail);
            }
            else
            {
                OrderDetails.FirstOrDefault(order => order.MenuItemId == menuItem.Id).Quantity += 1;
            }
         }

        public void RemoveFromCart(string itemId)
        {
            var orderDetail = OrderDetails.FirstOrDefault(item => item.Id == itemId);
            if(orderDetail.Quantity > 1)
            {
                OrderDetails.FirstOrDefault(item => item.Id == itemId).Quantity -= 1;
            }
            else
            {
                OrderDetails.Remove(orderDetail);
            }
        }

        private string GetId()
        {
            var id = Guid.NewGuid().ToString();
            while (_context.OrderDetails.FirstOrDefault(item => item.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
        private decimal GetTotal()
        {
            return OrderDetails.Sum(item => (item.Price * item.Quantity));
        }
    }
}
