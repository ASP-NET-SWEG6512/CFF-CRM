using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }
        //FK user
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        [ForeignKey("PhoneType")]
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }

        [ForeignKey("PhonePriority")]
        public int PhonePriorityId { get; set; }
        public PhonePriority PhonePriority { get; set; }

    }
}
