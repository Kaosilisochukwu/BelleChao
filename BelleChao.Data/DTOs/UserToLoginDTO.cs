using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class UserToLoginDTO
    {
        [Required(ErrorMessage ="Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password field is required")]
        public string Password { get; set; }
    }
}
