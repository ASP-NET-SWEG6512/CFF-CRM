using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFF_CRM.Models
{
    public class TaskUpdate
    {
        public int TaskUpdateId { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task task { get; set; }

        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
