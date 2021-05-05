using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class UploadFormFileViewModel
    {
        public List<IFormFile> FormFiles { get; set; }
    }
}
