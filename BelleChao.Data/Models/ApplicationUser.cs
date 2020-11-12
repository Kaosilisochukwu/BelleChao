using Microsoft.AspNetCore.Identity;
using System;

namespace BelleChao.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
