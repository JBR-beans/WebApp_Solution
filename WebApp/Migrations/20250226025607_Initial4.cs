using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryId",
                table: "Content",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Category_CategoryId",
                table: "Content",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Category_CategoryId",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_CategoryId",
                table: "Content");
        }
    }
}
