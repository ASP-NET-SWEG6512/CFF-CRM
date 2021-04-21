using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFF_CRM.Models
{
    public class User : IdentityUser
    {
        [NotMapped] 
        public IList<string> RoleNames { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //permission  //may not need Permission cuz Identity provided Permission functionalities
        public int? PermissionId { get; set; }
        public Permission Permission { get; set; }
        public string SaltKey { get; set; }
        public int Timeout { get; set; }
        [NotMapped]
        public PhoneNumber CustomPhoneNumber { get; set; }
        //default value
        public User()
        {
            Timeout = 5;
        }

    }
}
