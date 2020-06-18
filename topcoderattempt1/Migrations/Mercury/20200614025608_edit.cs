using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserLocationID",
                table: "UserPermissions",
                column: "locationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocationAssignments_UserId",
                table: "UserLocationAssignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocationAssignments_Users_UserId",
                table: "UserLocationAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_UserLocationAssignments_UserLocationID",
                table: "UserPermissions",
                column: "locationId",
                principalTable: "UserLocationAssignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocationAssignments_Users_UserId",
                table: "UserLocationAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_UserLocationAssignments_UserLocationID",
                table: "UserPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_UserLocationID",
                table: "UserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserLocationAssignments_UserId",
                table: "UserLocationAssignments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");
        }
    }
}
