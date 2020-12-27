using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffProductNew.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[] { 1, 1 });
        }
    }
}
