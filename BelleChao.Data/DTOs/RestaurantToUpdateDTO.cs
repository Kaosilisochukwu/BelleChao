﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.DTOs
{
    public class RestaurantToUpdateDTO
    {

        [Required(ErrorMessage = "Restaurant Name is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Restaurant Name must not exceed 100 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant Address is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Restaurant Address must not exceed 100 Characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City Field is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "City Field is must not exceed 100 Characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Field is required", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "State Field is must not exceed 100 Characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }

        public string PhotoUrl { get; set; }

        public string PhotoPublicId { get; set; }

        public int Rating { get; set; }
    }
}
