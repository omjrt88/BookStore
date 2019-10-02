using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Published = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Qualification = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthday", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J. K. Rowling" },
                    { 2, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "J. R. R. Tolkien" },
                    { 3, new DateTime(1969, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jojo Moyes" },
                    { 4, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen King" },
                    { 5, new DateTime(1972, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paula Hawkins" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ciencia Ficcion" },
                    { 2, "Romance" },
                    { 3, "Terror" },
                    { 4, "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "IsAdmin", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Omar Rodriguez", "1234", "omjrt88" },
                    { 2, new DateTime(1983, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bruce Wayne", "1234", "batman" },
                    { 3, new DateTime(2000, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Naruto Uzumaki", "1234", "kyubi" },
                    { 4, new DateTime(1920, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Diane Prince", "1234", "wwoman" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Name", "Published" },
                values: new object[,]
                {
                    { 1, 1, 1, "Harry Potter and the Sorcerer's Stone", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, "Harry Potter and the Chamber of Secrets", new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, "Harry Potter and the Prisoner of Azkaban", new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 1, "The Hobbit", new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 1, "The Silmarillion", new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, 2, "Me before you", new DateTime(2012, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, 2, "Me after you", new DateTime(2014, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, 3, "IT", new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5, 4, "The Girl on the Train", new DateTime(2015, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "Created", "Qualification", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Amazing Book! Recommended to all ages.", new DateTime(2018, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 2, 2, "Nothing compare to the first one. The author lost imagination.", new DateTime(2019, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 3, 3, "All the mistery related to Sirius and how betrayed Harry's parent was brilliant.", new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 7, 6, "I love it!.", new DateTime(2018, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 8, 6, "Boring.", new DateTime(2018, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 4, 8, "I hate clowns.", new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, 8, "I'm not clown's fan, but this had a good narrative.", new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 6, 8, "Meh!.", new DateTime(2019, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 9, 9, "Master piece.", new DateTime(2015, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 10, 9, "I'm the best World's detective and I could imagine the end. Awesome book.", new DateTime(2015, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 11, 9, "This was the best book I read!.", new DateTime(2015, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 12, 9, "OMG, the twist! I had another perspective about what was going on!", new DateTime(2016, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
