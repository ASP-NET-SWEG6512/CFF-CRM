using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options) { }
        public DbSet<OrderItem> OrderItems { get; set; }//
        public DbSet<Permission> Permissions { get; set; }//
        public DbSet<PermissionGroupPolicy> PermissionGroupPolicies { get; set; }//
        public DbSet<Attachment> Attachments { get; set; }//
        public DbSet<Note> Notes { get; set; }//
        public DbSet<PasswordReset> PasswordResets { get; set; }//
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }//
        public DbSet<PhonePriority> PhonePriorities { get; set; }//
        public DbSet<PhoneType> PhoneTypes { get; set; }//
        public DbSet<Priority> Priorities { get; set; }//
        public DbSet<Related> Related { get; set; }//
        public DbSet<Status> Status { get; set; }//
        public DbSet<SupplyRequestNote> SupplyRequestNotes { get; set; }//
        public DbSet<SupplyRequestOrigin> SupplyRequestOrigins { get; set; }//
        public DbSet<SupplyRequestType> SupplyRequestTypes { get; set; }//
        public DbSet<SupplyRequest> SupplyRequests { get; set; }//
        public DbSet<Task> Tasks { get; set; }//
        public DbSet<TaskNote> TaskNotes { get; set; }//
        public DbSet<TaskType> TaskTypes { get; set; }//
        public DbSet<User> Users { get; set; }//

        // List of OrderItems
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //status
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Name = "New", Color = "#0d47a1" },
                new Status { StatusId = 2, Name = "In-Process", Color = "#1a237e" },
                new Status { StatusId = 3, Name = "Completed", Color = "#10A037" },
                new Status { StatusId = 4, Name = "On Hold", Color = "#ED9E1E" },
                new Status { StatusId = 5, Name = "Cancelled", Color = "#DE1313" }
                );
            //Order item list
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem {OrderItemId = 1,Name = "Preneed agreement" },
                new OrderItem {OrderItemId = 2, Name = "Account update/Claim form" },
                new OrderItem { OrderItemId = 3, Name = "Itemizations form"},
                new OrderItem { OrderItemId = 4, Name = "Return envelopes"},
                new OrderItem { OrderItemId = 5, Name = "Postage paid envelopes" },
                new OrderItem { OrderItemId = 6, Name = "Deposit tickets" },
                new OrderItem { OrderItemId = 7, Name = "Planning guides" },
                new OrderItem { OrderItemId = 8, Name = "Funding your funeral in advance brochure" },
                new OrderItem { OrderItemId = 9, Name = "Monthly monitors" },
                new OrderItem { OrderItemId = 10, Name = "Service and merchandise forms" },
                new OrderItem { OrderItemId = 11, Name = "Investment election form" },
                new OrderItem { OrderItemId = 12, Name = "Other" }
                );
            //supply request origin

            modelBuilder.Entity<SupplyRequestOrigin>().HasData(
                new SupplyRequestOrigin { SupplyRequestOriginId = 1, Name = "Phone"},
                new SupplyRequestOrigin { SupplyRequestOriginId = 2, Name = "Fax" },
                new SupplyRequestOrigin { SupplyRequestOriginId = 3, Name = "Email" },
                new SupplyRequestOrigin { SupplyRequestOriginId = 4, Name = "Mail" },
                new SupplyRequestOrigin { SupplyRequestOriginId = 5, Name = "Reginal Manager" },
                new SupplyRequestOrigin { SupplyRequestOriginId = 6, Name = "Other" }
                );

            //suppy request type
            modelBuilder.Entity<SupplyRequestType>().HasData(
                new SupplyRequestType { SupplyRequestTypeId = 1, Name = "Vendor"},
                new SupplyRequestType { SupplyRequestTypeId = 2, Name = "Client" }
                );

            //related to 
            modelBuilder.Entity<Related>().HasData(
                new Related { RelatedId = 1, Name = "Customer"},
                new Related { RelatedId = 2, Name = "Potential customer" },
                new Related { RelatedId = 3, Name = "Lead" },
                new Related { RelatedId = 4, Name = "In-house" },
                new Related { RelatedId = 5, Name = "Other" }
                );

            //Task type
            modelBuilder.Entity<TaskType>().HasData(
                new TaskType { TaskTypeId = 1, Name = "Reminder call" },
                new TaskType { TaskTypeId = 2, Name = "Follow-up" }
                );

            //task priority
            modelBuilder.Entity<Priority>().HasData(
                new Priority { PriorityId = 1, Name = "High"},
                new Priority { PriorityId = 2, Name = "Medium" },
                new Priority { PriorityId = 3, Name = "Low" }
                );
            //phone number type
            modelBuilder.Entity<PhoneType>().HasData(
                new PhoneType { PhoneTypeId = 1, Name = "Home"},
                new PhoneType { PhoneTypeId = 2, Name = "Mobile" },
                new PhoneType { PhoneTypeId = 3, Name = "Work" },
                new PhoneType { PhoneTypeId = 4, Name = "Other" }
                );
            //Permission list
            modelBuilder.Entity<Permission>().HasData(
                new Permission { PermissionId = 1, Name = "Administrator"},
                new Permission { PermissionId = 2, Name = "User"},
                new Permission { PermissionId = 3, Name = "Visitor"}
                );
            
        }
        
    }
}
