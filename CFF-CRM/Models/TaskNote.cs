using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class TaskNote
    {
        public int TaskNoteId { get; set; }
        public int TaskId { get; set; }
        public int NoteId { get; set; }
    }
}
