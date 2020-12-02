using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffProductNew.Migrations
{
    public partial class updatedproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Stock",
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Ean", "ExpectedRestock", "InStock", "Name", "Price" },
                values: new object[] { 2, 1, 1, "not sure", new DateTime(2020, 12, 17, 10, 30, 50, 0, DateTimeKind.Unspecified), true, "Chicken dumpling", 12m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
