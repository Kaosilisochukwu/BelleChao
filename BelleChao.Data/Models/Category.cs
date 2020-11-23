using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
    }
}
