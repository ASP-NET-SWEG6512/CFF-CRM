using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
    }
}
