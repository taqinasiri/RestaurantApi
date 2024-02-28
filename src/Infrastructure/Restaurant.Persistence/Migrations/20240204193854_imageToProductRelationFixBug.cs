using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class imageToProductRelationFixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProduct_Products_ImageId",
                table: "ImageToProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProduct_Products_ProductId",
                table: "ImageToProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProduct_Products_ProductId",
                table: "ImageToProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProduct_Products_ImageId",
                table: "ImageToProduct",
                column: "ImageId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}