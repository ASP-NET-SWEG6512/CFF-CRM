using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status status { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        public string Owner { get; set; }

        [ForeignKey("Related")]
        public int RelatedId { get; set; }
        public Related related { get; set; }

        public string RelatedName { get; set; }

        [ForeignKey("TaskType")]
        public int TaskTypeId { get; set; }
        public TaskType taskType { get; set; }

        [ForeignKey("Priority")]
        public int PriorityId { get; set; }
        public Priority priority { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        public Task()
        {
            CreatedTime = DateTime.Now;
        }
    }
}
