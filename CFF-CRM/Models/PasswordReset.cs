using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class PasswordReset
    {
        public int PasswordResetId { get; set; }
        public string ResetToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
