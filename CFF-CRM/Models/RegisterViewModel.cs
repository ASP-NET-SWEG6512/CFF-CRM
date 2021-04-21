using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CFF_CRM.Models
{
    public class RegisterViewModel
    {

        //public RegisterViewModel(User user)
        //{
        //    this.Username = user.UserName;
        //    this.FirstName = user.FirstName;
        //    this.LastName = user.LastName;
        //    this.PhoneNumber = user.PhoneNumber;
        //    this.Roles = user.RoleNames;
        //    this.Email = user.Email;
        //}

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }


        //public PhoneNumber PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public int? PhoneNumberTypeId { get; set; }

        public int? PhoneNumberPriorityId { get; set; }

        public IList<string> Roles { get; set; }
    }
}
