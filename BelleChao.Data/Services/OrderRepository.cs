using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CancelOrder(string orderId)
        {
            var orders = await GetOrders();
            var order = _context.Orders.FirstOrDefault(order => order.Id == orderId);

            if (order == null)
            {
                return false;
            }
            order.IsActive = false;
            var updateResult = _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeclineOrder(string orderId)
        {
            var orders = await GetOrders();
            var order = _context.Orders.FirstOrDefault(order => order.Id == orderId);

            if (order == null)
            {
                return false;
            }
            order.IsActive = false;
            var updateResult = _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DispatchOrder(string orderId)
        {
            var orders = await GetOrders();
            var order = _context.Orders.FirstOrDefault(order => order.Id == orderId);

            if (order == null)
            {
                return false;
            }
            order.IsDispatched = false;
            var updateResult = _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
           return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersById(string orderId)
        {
            return await _context.Orders.Where(order => order.Id == orderId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByRestaurant(string restaurantId)
        {
            return await _context.Orders.Where(order => order.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(string userId)
        {
            return await _context.Orders.Where(order => order.UserId == userId).ToListAsync();
        }

        public async Task<string> PlaceOrder(OrderToPlaceDTO order)
        {
            var id = generateId();
            var orderPlaceResult = _context.Orders.Add(new Order
            {
                Id = id,
                DeliveryAddress = order.DeliveryAddress,
                OrderDetails = order.OrderDetails,
                UserId = order.UserId,
                IsActive = true,
                TotalAmount = order.OrderDetails.Sum(orderDetail => orderDetail.Price * orderDetail.Quantity),
                RestaurantId = order.RestaurantId,
            }); 
            if(orderPlaceResult.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return id;
            }
            return "Not Placed";
        }

        string generateId()
        {
            var id = Guid.NewGuid().ToString();
            while(_context.Orders.Where(order => order.Id == id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }

        public async Task<int> RecieveOrder(string orderId)
        {
            int updateResult = 0;
            var order = _context.Orders.FirstOrDefault(order => order.Id == orderId);
            if (order != null)
            {
                order.IsDelivered = true;
                updateResult = await _context.SaveChangesAsync();
                return updateResult;
            }
            return updateResult;
        }
    }
}
