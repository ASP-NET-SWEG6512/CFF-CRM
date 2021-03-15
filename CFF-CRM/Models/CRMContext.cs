using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Models
{
    public class CRMContext:DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options) { }
        public DbSet<OrderItem> OrderItems { get; set; }

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
