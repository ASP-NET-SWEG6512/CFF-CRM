using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFF_CRM.Models
{
    public class PermissionGroupPolicy
    {
        //By Page Access
        public int PermissionGroupPolicyId { get; set; }
        public string Page { get; set; } //either Task, SupplyRequest, or Admin

        public string Action { get; set; }//action includes read,write,archive,ArchiveForOwner
    }
}
