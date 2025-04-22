using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items",
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses",
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items",
                }
            );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Laptop",
                   Description = "Electronic Items",
                   CategoryId = 1,
                   Price = 50000
               },
               new Product
               {
                   Id = 2,
                   Name = "Tab",
                   Description = "Electronic Items",
                   CategoryId = 1,
                   Price = 30000
               },
               new Product
               {
                   Id = 3,
                   Name = "Rice",
                   Description = "Grocery Items",
                   CategoryId = 3,
                   Price = 300
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
