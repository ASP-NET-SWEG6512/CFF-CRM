using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class TaskNote
    {
        public int TaskNoteId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task task { get; set; }
        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public Note note { get; set; }
    }
}
