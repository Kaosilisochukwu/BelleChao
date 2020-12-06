using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.Models
{
    public class Order
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [DisplayName("Customer Id")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [DisplayName("Restaurant Id")]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        public bool IsDelivered { get; set; } = false;
        public bool IsDispatched { get; set; } = false;
        public bool IsActive { get; set; } = true;

        [Required]
        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
