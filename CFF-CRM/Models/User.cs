using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CFF_CRM.Models
{
    public class User : IdentityUser
    {
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //permission
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        public string SaltKey { get; set; }
        public int Timeout { get; set; }

        //default value
        public User()
        {
            Timeout = 5;
        }

    }
}
