using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffProductNew.Migrations
{
    public partial class stockadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                schema: "Stock",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "Stock",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                schema: "Stock",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "Stock",
                newName: "Orders",
                newSchema: "Stock");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Stock",
                newName: "Categories",
                newSchema: "Stock");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "Stock",
                newName: "Brands",
                newSchema: "Stock");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "Stock",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "Stock",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                schema: "Stock",
                table: "Brands",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stock",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "Stock",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stock",
                value: 38);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "Stock",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "Stock",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                schema: "Stock",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "Stock",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Stock",
                newName: "Order",
                newSchema: "Stock");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "Stock",
                newName: "Category",
                newSchema: "Stock");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "Stock",
                newName: "Brand",
                newSchema: "Stock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                schema: "Stock",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "Stock",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                schema: "Stock",
                table: "Brand",
                column: "Id");
        }
    }
}
