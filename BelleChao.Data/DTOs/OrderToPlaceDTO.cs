using BelleChao.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class OrderToPlaceDTO
    {
        [Required]
        [DisplayName("Customer Id")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [DisplayName("Restaurant Id")]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
