using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addBranchTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)",maxLength: 100,nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)",maxLength: 100,nullable: false),
                    Description = table.Column<string>(type: "ntext",maxLength: 5000,nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)",maxLength: 200,nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches",x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageToBranch",
                columns: table => new
                {
                    ImageId = table.Column<long>(type: "bigint",nullable: false),
                    BranchId = table.Column<long>(type: "bigint",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageToBranch",x => new { x.BranchId,x.ImageId });
                    table.ForeignKey(
                        name: "FK_ImageToBranch_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageToBranch_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToBranch",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint",nullable: false),
                    BranchId = table.Column<long>(type: "bigint",nullable: false),
                    Price = table.Column<int>(type: "int",nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit",nullable: false),
                    IsActive = table.Column<bool>(type: "bit",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToBranch",x => new { x.ProductId,x.BranchId });
                    table.ForeignKey(
                        name: "FK_ProductToBranch_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToBranch_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageToBranch_ImageId",
                table: "ImageToBranch",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToBranch_BranchId",
                table: "ProductToBranch",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageToBranch");

            migrationBuilder.DropTable(
                name: "ProductToBranch");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}