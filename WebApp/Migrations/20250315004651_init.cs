using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Content_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "author_id", "author_name" },
                values: new object[,]
                {
                    { 1, "18ed883f-6523-4b19-9d31-d3d8315db70f", "TheAuthor" },
                    { 2, "9f5c7b02-3d4e-4b62-91b7-8e2a9c1d6f3a", "meowmeow:3" },
                    { 3, "c1a8e5f7-7b2d-4c39-9e8f-12d4a6b0f9c3", "Hi, I like cheese" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Tech" },
                    { 3, "News" },
                    { 4, "Tacos" }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "ContentId", "AuthorId", "Body", "CategoryId", "CreatedAt", "Title", "UpdatedAt", "Visibility" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum and stuff", 1, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Post", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 2, "Lorem ipsum and stuff x2", 2, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Post", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 3, "Lorem ipsum and stuff, :3", 3, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third Post", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_AuthorId",
                table: "Content",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryId",
                table: "Content",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
