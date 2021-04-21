using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CFF_CRM.Models
{
    public class PasswordViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter your current password.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter a new password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your new password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
