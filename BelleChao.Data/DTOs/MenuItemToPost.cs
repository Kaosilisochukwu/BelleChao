using BelleChao.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.DTOs
{
    public class MenuItemToPost
    {
        [Required]
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [DisplayName("Restaurant Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please give a brief description of this item")]
        public string Description { get; set; }

        public string PhotoUrl { get; set; }
        public string PhotoPublicId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
