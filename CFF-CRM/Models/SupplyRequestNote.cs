using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFF_CRM.Models
{
    public class SupplyRequestNote
    {
        public int SupplyRequestNoteId { get; set; }
        [ForeignKey("SupplyRequest")]
        public int SupplyRequestId { get; set; }
        public SupplyRequest supplyRequest { get; set; }
        public int NoteId { get; set; }
    }
}
