using System;
using System.Collections.Generic;
using System.Text;

namespace BelleChao.Data.DTOs
{
    public class PasswordChangeDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
