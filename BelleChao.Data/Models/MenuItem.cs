using System;

namespace BelleChao.Data.Models
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string PhotoUrl { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
