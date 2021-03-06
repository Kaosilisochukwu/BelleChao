﻿using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class MenuItemToAddDTO
    {
        public Restaurant Restaurant { get; set; }

        [Required]
        [DisplayName("Restaurant Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please give a brief description of this item")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please give a brief description of this item")]
        public IFormFile Photo { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
