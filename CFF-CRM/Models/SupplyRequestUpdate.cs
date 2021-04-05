using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class SupplyRequestUpdate
    {
        public int SupplyRequestUpdateId { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task task { get; set; }

        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
