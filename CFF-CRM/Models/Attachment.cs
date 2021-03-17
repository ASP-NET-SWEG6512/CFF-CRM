using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int TaskId { get; set; }
        public string Link { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
