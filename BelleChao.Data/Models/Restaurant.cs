using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace BelleChao.Data.Models
{
    public class Restaurant
    {
        [Key]
        [Required(ErrorMessage ="Restaurant Id is required")]
        public string Id { get; set; }

        [Required(ErrorMessage ="Restaurant Name is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Restaurant Name must not exceed 100 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant Address is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Restaurant Address must not exceed 100 Characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }

        [Required(ErrorMessage = "City Field is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "City Field is must not exceed 100 Characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Field is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "State Field is must not exceed 100 Characters")]
        public string State { get; set; }

        public int Rating { get; set; }
    }
}
