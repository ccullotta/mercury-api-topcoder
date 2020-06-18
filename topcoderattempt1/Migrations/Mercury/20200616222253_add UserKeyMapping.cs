using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class addUserKeyMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KetSerialNumber",
                table: "UserKeyMaps");

            migrationBuilder.AddColumn<string>(
                name: "KeySerialNumber",
                table: "UserKeyMaps",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserKeyMaps_KeySerialNumber",
                table: "UserKeyMaps",
                column: "KeySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeyMaps_LocationId",
                table: "UserKeyMaps",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeyMaps_UserID",
                table: "UserKeyMaps",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Keyholders_KeySerialNumber",
                table: "Keyholders",
                column: "KeySerialNumber",
                unique: true,
                filter: "[KeySerialNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyholders_UserKeyMaps_KeySerialNumber",
                table: "Keyholders",
                column: "KeySerialNumber",
                principalTable: "UserKeyMaps",
                principalColumn: "KeySerialNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKeyMaps_Locations_LocationId",
                table: "UserKeyMaps",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKeyMaps_Users_UserID",
                table: "UserKeyMaps",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keyholders_UserKeyMaps_KeySerialNumber",
                table: "Keyholders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKeyMaps_Locations_LocationId",
                table: "UserKeyMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKeyMaps_Users_UserID",
                table: "UserKeyMaps");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserKeyMaps_KeySerialNumber",
                table: "UserKeyMaps");

            migrationBuilder.DropIndex(
                name: "IX_UserKeyMaps_LocationId",
                table: "UserKeyMaps");

            migrationBuilder.DropIndex(
                name: "IX_UserKeyMaps_UserID",
                table: "UserKeyMaps");

            migrationBuilder.DropIndex(
                name: "IX_Keyholders_KeySerialNumber",
                table: "Keyholders");

            migrationBuilder.DropColumn(
                name: "KeySerialNumber",
                table: "UserKeyMaps");

            migrationBuilder.AddColumn<string>(
                name: "KetSerialNumber",
                table: "UserKeyMaps",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
