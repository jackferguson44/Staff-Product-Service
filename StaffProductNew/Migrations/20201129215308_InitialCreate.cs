using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffProductNew.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stock");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStockOrder",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStockOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductEan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    ExpectedRestock = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestStockOrder",
                schema: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestStockOrder", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Brand",
                columns: new[] { "Id", "AvailableProductCount", "Name" },
                values: new object[] { 1, 20, "kellogs" });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Category",
                columns: new[] { "Id", "AvailableProductCount", "Description", "Name" },
                values: new object[] { 1, 20, "Food", "Meat" });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "CustomerStockOrder",
                columns: new[] { "Id", "ProductId", "ProductName", "Quantity" },
                values: new object[] { 1, 1, "tasty chicken", 2 });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Order",
                columns: new[] { "Id", "ProductEan", "ProductId", "ProductName", "Quantity", "TotalPrice", "When" },
                values: new object[] { 1, "Not sure", 1, "Chicken", 5, 25m, new DateTime(2020, 12, 29, 10, 30, 50, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Ean", "ExpectedRestock", "InStock", "Name", "Price" },
                values: new object[] { 1, 1, 1, "not sure", new DateTime(2020, 12, 25, 10, 30, 50, 0, DateTimeKind.Unspecified), true, "tasty chicken", 5m });

            migrationBuilder.InsertData(
                schema: "Stock",
                table: "PurchaseRequestStockOrder",
                columns: new[] { "Id", "ProductId", "ProductName", "Quantity" },
                values: new object[] { 1, 1, "tasty chicken", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "CustomerStockOrder",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "PurchaseRequestStockOrder",
                schema: "Stock");
        }
    }
}
