using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setBrachSlugAndTitileUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Branches_Slug",
                table: "Branches",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Title",
                table: "Branches",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branches_Slug",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Title",
                table: "Branches");
        }
    }
}