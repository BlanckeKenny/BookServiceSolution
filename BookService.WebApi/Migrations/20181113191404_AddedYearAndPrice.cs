using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.WebApi.Migrations
{
    public partial class AddedYearAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Book",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Year" },
                values: new object[] { 22.15m, 2010 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Year" },
                values: new object[] { 29.15m, 2001 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Year" },
                values: new object[] { 15.15m, 2005 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "Year" },
                values: new object[] { 30.15m, 2018 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "Year" },
                values: new object[] { 28.15m, 2015 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "Year" },
                values: new object[] { 15m, 2005 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "Year" },
                values: new object[] { 18m, 2010 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Book");
        }
    }
}
