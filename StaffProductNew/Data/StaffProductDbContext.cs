using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffProductNew.Data
{
    public class StaffProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StaffProductDbContext(DbContextOptions<StaffProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Stock");

            modelBuilder.Entity<Order>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Order>()
                .HasData(
                            new Order { Id = 1, ProductId = 1, Quantity = 5, When = new DateTime(2020, 12, 29, 10, 30, 50), ProductName = "Chicken", ProductEan = "Not sure", TotalPrice = 25m}
                );

            modelBuilder.Entity<Brand>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Brand>()
                .HasData(
                            new Brand { Id = 1, Name = "kellogs", AvailableProductCount = 20 }
                );

            modelBuilder.Entity<Category>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasData(
                            new Category { Id = 1, Name = "Meat", Description = "Food", AvailableProductCount = 20}
                );

            modelBuilder.Entity<Product>()
                .HasData(
                           new Product { Id = 1, Ean = "not sure", CategoryId = 1, BrandId = 1, Name = "tasty chicken", Price = 5m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50) },
                           new Product { Id = 2, Ean = "not sure", CategoryId = 1, BrandId = 1, Name = "Chicken dumpling", Price = 12m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 17, 10, 30, 50) }
                );

            modelBuilder.Entity<CustomerStockOrder>()
                .HasKey(p => p.Id
                );

            modelBuilder.Entity<CustomerStockOrder>()
                .HasData(
                        new CustomerStockOrder { Id = 1, ProductId = 1, ProductName = "tasty chicken", Quantity = 2}
                );

            modelBuilder.Entity<PurchaseRequestStockOrder>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PurchaseRequestStockOrder>()
                .HasData(
                            new PurchaseRequestStockOrder { Id = 1, ProductId = 1, ProductName = "tasty chicken", Quantity = 2 }
                );
        }

    }
}
