using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelleChao.Data.Services
{
    public interface IOrderServices
    {
        public Task AddOrderItem(string menuItemId);
        public Task RemoveOrderItem(string menuItemId);
        public Task Checkout(string orderId);
        public Task<decimal> GetOrderTotal();
        public Task ClearCart();
    }
}
