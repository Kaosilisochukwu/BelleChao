using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.Models
{
    public class OrderDetail
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [DisplayName("Menu Item Id")]
        public string MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        [Required(ErrorMessage = "Quantity field is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price field is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Order Id field is required")]
        [DisplayName("Order Id")]
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
