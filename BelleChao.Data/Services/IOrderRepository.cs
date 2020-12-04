using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByUserId(string userId);
        Task<IEnumerable<Order>> GetOrdersByRestaurant(string restaurantId);

        Task<IEnumerable<Order>> GetOrdersById(string orderId);
        Task<string> PlaceOrder(OrderToPlaceDTO order);
        Task<bool> CancelOrder(string orderId);

        Task<bool> ApproveOrder(string orderId);
        Task<bool> DeclineOrder(string orderId);

        Task<bool> DispatchOrder(string orderId);

        Task<bool> RecieveOrder(string orderId);
        
    }
}
