using System;
using System.Collections.Generic;
using System.Text;

namespace BelleChao.Data.Models
{
    public class Order
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string RestaurantId { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveryAddress { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
