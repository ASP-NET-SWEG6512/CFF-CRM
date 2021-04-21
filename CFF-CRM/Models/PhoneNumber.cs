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
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("PhoneType")]
        public int? PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }

        [ForeignKey("PhonePriority")]
        public int? PhonePriorityId { get; set; }
        public PhonePriority PhonePriority { get; set; }

        [DataType(DataType.PhoneNumber)] //phone number data type in db
        [Phone] //phone number validation
        public string Number { get; set; }

    }
}
