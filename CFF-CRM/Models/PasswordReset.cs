using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class PasswordReset
    {
        public int PasswordResetId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }
        public string ResetToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
