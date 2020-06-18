using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class addfktochangeemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserModelUserID",
                table: "EmailChangeRequests",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
