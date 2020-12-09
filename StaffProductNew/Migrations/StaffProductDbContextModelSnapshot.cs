﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffProductNew.Data;

namespace StaffProductNew.Migrations
{
    [DbContext(typeof(StaffProductDbContext))]
    partial class StaffProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Stock")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("StaffProductNew.Data.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AvailableProductCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableProductCount = 20,
                            Name = "kellogs"
                        });
                });

            modelBuilder.Entity("StaffProductNew.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AvailableProductCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableProductCount = 20,
                            Description = "Food",
                            Name = "Meat"
                        });
                });

            modelBuilder.Entity("StaffProductNew.Data.CustomerStockOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerStockOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            ProductName = "tasty chicken",
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("StaffProductNew.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ProductEan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductEan = "Not sure",
                            ProductId = 1,
                            ProductName = "Chicken",
                            Quantity = 5,
                            TotalPrice = 25m,
                            When = new DateTime(2020, 12, 29, 10, 30, 50, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StaffProductNew.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Ean")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedRestock")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Ean = "not sure",
                            ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50, 0, DateTimeKind.Unspecified),
                            InStock = true,
                            Name = "tasty chicken",
                            Price = 5m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            CategoryId = 1,
                            Ean = "not sure",
                            ExpectedRestock = new DateTime(2020, 12, 17, 10, 30, 50, 0, DateTimeKind.Unspecified),
                            InStock = true,
                            Name = "Chicken dumpling",
                            Price = 12m,
                            Stock = 38
                        });
                });

            modelBuilder.Entity("StaffProductNew.Data.PurchaseRequestStockOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurchaseRequestStockOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            ProductName = "tasty chicken",
                            Quantity = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
