using Microsoft.EntityFrameworkCore;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.DBContexts
{
    public class OrdersContext :DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Name = "ElectronicOrder",
                    Description = "Electronic Order",
                    NoOfItems=3,
                    Total=100000
                },
                new Order
                {
                    Id = 2,
                    Name = "ClothesOrder",
                    Description = "Dresses",
                    NoOfItems = 9,
                    Total = 70000
                },
                new Order
                {
                    Id = 3,
                    Name = "GroceryOrder",
                    Description = "Grocery Items",
                    NoOfItems = 10,
                    Total = 1000
                }
            );

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
