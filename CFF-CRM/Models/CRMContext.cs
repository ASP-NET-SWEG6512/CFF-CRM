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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhonePriority> PhonePriorities { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Related> Related { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SupplyRequestNote> SupplyRequestNotes { get; set; }
        public DbSet<SupplyRequestOrigin> SupplyRequestOrigins { get; set; }
        public DbSet<SupplyRequestType> SupplyRequestTypes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<User> Users { get; set; }

        // List of OrderItems
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem {OrderItemId = 1,Name = "Preneed agreement" },
                new OrderItem {OrderItemId = 2, Name = "Account update/Claim form" }
                );
        }
        
    }
}
