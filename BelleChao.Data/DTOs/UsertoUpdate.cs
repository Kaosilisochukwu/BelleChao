﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class UsertoUpdate
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

            [EmailAddress]
            [Required(ErrorMessage = "Email Address is required")]
            public string Email { get; set; }
            public string Username { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required")]
            public string PhoneNumber { get; set; }

            [Required(AllowEmptyStrings = false)]
            [MaxLength(100, ErrorMessage = "City must not have more than 50 characters")]
            public string City { get; set; }

            [Required(AllowEmptyStrings = false)]
            [MaxLength(100, ErrorMessage = "State must not have more than 50 characters")]
            [MinLength(2)]
            public string State { get; set; }
        }
    }
