using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditUserRoleTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesProjects_Roles_RoleId",
                table: "UserRolesProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesProjects_Users_UserId",
                table: "UserRolesProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRolesProjects",
                table: "UserRolesProjects");

            migrationBuilder.RenameTable(
                name: "UserRolesProjects",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolesProjects_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId","RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRolesProjects");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRolesProjects",
                newName: "IX_UserRolesProjects_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRolesProjects",
                table: "UserRolesProjects",
                columns: new[] { "UserId","RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesProjects_Roles_RoleId",
                table: "UserRolesProjects",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesProjects_Users_UserId",
                table: "UserRolesProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}