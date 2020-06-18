using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class addChangeEmailRequests1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailChangeRequests_Users_UserModelUserID",
                table: "EmailChangeRequests");

            migrationBuilder.DropIndex(
                name: "IX_EmailChangeRequests_UserModelUserID",
                table: "EmailChangeRequests");

            migrationBuilder.DropColumn(
                name: "UserModelUserID",
                table: "EmailChangeRequests");

            migrationBuilder.CreateIndex(
                name: "IX_EmailChangeRequests_UserId",
                table: "EmailChangeRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailChangeRequests_Users_UserId",
                table: "EmailChangeRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailChangeRequests_Users_UserId",
                table: "EmailChangeRequests");

            migrationBuilder.DropIndex(
                name: "IX_EmailChangeRequests_UserId",
                table: "EmailChangeRequests");

            migrationBuilder.AddColumn<int>(
                name: "UserModelUserID",
                table: "EmailChangeRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailChangeRequests_UserModelUserID",
                table: "EmailChangeRequests",
                column: "UserModelUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailChangeRequests_Users_UserModelUserID",
                table: "EmailChangeRequests",
                column: "UserModelUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
