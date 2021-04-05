using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }

        [ForeignKey("Status")]
        public int TaskId { get; set; }
        public Task task { get; set; }
        public string Link { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
