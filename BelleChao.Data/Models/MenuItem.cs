using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.Models
{
    public class MenuItem
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [DisplayName("Restaurant Id")]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [DisplayName("Restaurant Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } 

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
