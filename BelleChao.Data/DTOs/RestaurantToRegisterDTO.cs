﻿using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class RestaurantToRegisterDTO
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

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public IFormFile Photo { get; set; }
    }
}
