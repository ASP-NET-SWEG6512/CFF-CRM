using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class PermissionRelation
    {

        public int PermissionRelationId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        [ForeignKey("PermissionGroupPolicy")]
        public int PermissionGroupPolicyId { get; set; }
        public PermissionGroupPolicy PermissionGroupPolicy { get; set; }
    }
}
