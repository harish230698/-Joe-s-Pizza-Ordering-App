using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzaorder.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblPizza",
                keyColumn: "SNo",
                keyValue: 3,
                column: "ImagePath",
                value: "/ChesseNCorn.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblPizza",
                keyColumn: "SNo",
                keyValue: 3,
                column: "ImagePath",
                value: "/CheeseNCorn.jpg");
        }
    }
}
