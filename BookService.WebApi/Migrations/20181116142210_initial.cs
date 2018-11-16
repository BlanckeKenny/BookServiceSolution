using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Title = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()"),
                    Score = table.Column<int>(nullable: false),
                    ReaderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 16, 15, 22, 10, 550, DateTimeKind.Local), "James", "Sharp" },
                    { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 16, 15, 22, 10, 550, DateTimeKind.Local), "Sophie", "Netty" },
                    { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 16, 15, 22, 10, 550, DateTimeKind.Local), "Elisa", "Yammy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Created", "Name" },
                values: new object[,]
                {
                    { 1, "UK", new DateTime(2018, 11, 16, 15, 22, 10, 600, DateTimeKind.Local), "IT-Publishers" },
                    { 2, "Sweden", new DateTime(2018, 11, 16, 15, 22, 10, 600, DateTimeKind.Local), "FoodBooks" }
                });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 11, 16, 15, 22, 10, 622, DateTimeKind.Local), "trol", "brol" },
                    { 2, new DateTime(2018, 11, 16, 15, 22, 10, 622, DateTimeKind.Local), "Kenny", "blancke" },
                    { 3, new DateTime(2018, 11, 16, 15, 22, 10, 622, DateTimeKind.Local), "Jolande", "Minne" },
                    { 4, new DateTime(2018, 11, 16, 15, 22, 10, 622, DateTimeKind.Local), "Luka", "Blancke" },
                    { 5, new DateTime(2018, 11, 16, 15, 22, 10, 622, DateTimeKind.Local), "Louis", "Blancke" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book1.jpg", "123456789", 420, 22.15m, 1, "Learning C#", 2010 },
                    { 2, 2, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book2.jpg", "45689132", 360, 29.15m, 1, "Mastering Linq", 2001 },
                    { 3, 1, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book3.jpg", "15856135", 360, 15.15m, 1, "Mastering Xamarin", 2005 },
                    { 4, 2, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book1.jpg", "56789564", 360, 30.15m, 1, "Exploring ASP.Net Core 2.0", 2018 },
                    { 5, 2, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book2.jpg", "234546684", 420, 28.15m, 1, "Unity Game Development", 2015 },
                    { 6, 3, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book3.jpg", "789456258", 40, 15m, 2, "Cooking is fun", 2005 },
                    { 7, 3, new DateTime(2018, 11, 16, 15, 22, 10, 709, DateTimeKind.Local), "book3.jpg", "94521546", 53, 18m, 2, "Secret recipes", 2010 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "Created", "ReaderId", "Score" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 11, 16, 15, 22, 10, 611, DateTimeKind.Local), 1, 5 },
                    { 4, 1, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 3, 5 },
                    { 8, 1, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 1, 5 },
                    { 2, 2, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 1, 1 },
                    { 3, 2, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 2, 3 },
                    { 7, 2, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 2, 5 },
                    { 5, 3, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 3, 5 },
                    { 6, 3, new DateTime(2018, 11, 16, 15, 22, 10, 612, DateTimeKind.Local), 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReaderId",
                table: "Rating",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
