using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int PriorityId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
