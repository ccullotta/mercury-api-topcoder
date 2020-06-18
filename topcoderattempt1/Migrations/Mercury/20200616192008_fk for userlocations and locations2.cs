using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class fkforuserlocationsandlocations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocationAssignments_Location_LocationId",
                table: "UserLocationAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStatuses_Location_LocationId",
                table: "UsersStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocationAssignments_Locations_LocationId",
                table: "UserLocationAssignments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStatuses_Locations_LocationId",
                table: "UsersStatuses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocationAssignments_Locations_LocationId",
                table: "UserLocationAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStatuses_Locations_LocationId",
                table: "UsersStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocationAssignments_Location_LocationId",
                table: "UserLocationAssignments",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStatuses_Location_LocationId",
                table: "UsersStatuses",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
