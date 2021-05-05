using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public string Name { get; set; }
    }
}
