﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles",x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "bigint",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)",maxLength: 256,nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit",nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit",nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit",nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset",nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit",nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users",x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    RoleId = table.Column<long>(type: "bigint",nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims",x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int",nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    UserId = table.Column<long>(type: "bigint",nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims",x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)",nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)",nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    UserId = table.Column<long>(type: "bigint",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins",x => new { x.LoginProvider,x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint",nullable: false),
                    RoleId = table.Column<long>(type: "bigint",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles",x => new { x.UserId,x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint",nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)",nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)",nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens",x => new { x.UserId,x.LoginProvider,x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}