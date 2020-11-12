using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id field must not be empty")]
        [MaxLength(50, ErrorMessage = "Firstname must not have more than 50 characters")]
        [MinLength(2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name field must not be empty")]
        [MaxLength(50, ErrorMessage = "Last Name must not have more than 50 characters")]
        [MinLength(2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Last Name must not have more than 100 characters")]
        [MinLength(2)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "City must not have more than 50 characters")]
        [MinLength(2)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "State must not have more than 50 characters")]
        [MinLength(2)]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Image Url must not have more than 100 characters")]
        [MinLength(2)]
        [DisplayName("Avatar URL")]
        public string PhotoUrl { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
