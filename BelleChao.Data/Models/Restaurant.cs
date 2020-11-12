using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BelleChao.Data.Models
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Rating { get; set; }
    }
}
