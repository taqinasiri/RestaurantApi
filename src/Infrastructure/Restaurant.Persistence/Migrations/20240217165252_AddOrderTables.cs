using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    UserId = table.Column<long>(type: "bigint",nullable: false),
                    TableId = table.Column<long>(type: "bigint",nullable: false),
                    TableRentalMinutePrice = table.Column<int>(type: "int",nullable: false),
                    FromTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    TotalPrice = table.Column<int>(type: "int",nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)",maxLength: 500,nullable: true),
                    IsPay = table.Column<bool>(type: "bit",nullable: false),
                    RefId = table.Column<int>(type: "int",nullable: false),
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
                    table.PrimaryKey("PK_Order",x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    ProductId = table.Column<long>(type: "bigint",nullable: false),
                    OrderId = table.Column<long>(type: "bigint",nullable: false),
                    UnitPrice = table.Column<int>(type: "int",nullable: false),
                    Amount = table.Column<int>(type: "int",nullable: false),
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
                    table.PrimaryKey("PK_OrderItems",x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                table: "Order",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}