using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> ApproveOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeclineOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DispatchOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersById(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByRestaurant(string restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> PlaceOrder(OrderToPlaceDTO order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RecieveOrder(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
