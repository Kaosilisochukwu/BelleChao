using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class UserToLoginDTO
    {
        [Required(ErrorMessage ="Username field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password field is required")]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool IsPersistent { get; set; }
    }
}
