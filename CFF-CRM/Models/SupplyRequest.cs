using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class SupplyRequest
    {
        [Key]
        public int SupplyRequestId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status status { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public OrderItem orderItem { get; set; }

        [ForeignKey("SupplyRequestOrigin")]
        public int SupplyRequestOriginId { get; set; }
        public SupplyRequestOrigin supplyRequestOrigin { get; set; }

        [ForeignKey("SupplyRequestType")]
        public int SupplyRequestTypeId { get; set; }
        public SupplyRequestType supplyRequestType { get; set; }

        public string ClientName { get; set; }

        public string OwnerName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public SupplyRequest()
        {
            CreatedTime = DateTime.Now;
        }
    } 
}
