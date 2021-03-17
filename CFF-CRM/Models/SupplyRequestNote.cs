using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class SupplyRequestNote
    {
        public int SupplyRequestNoteId { get; set; }
        public int SupplyRequestId { get; set; }
        public int NoteId { get; set; }
    }
}
