using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class fkforuserlocationsandlocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersStatuses_LocationId",
                table: "UsersStatuses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocationAssignments_LocationId",
                table: "UserLocationAssignments",
                column: "LocationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocationAssignments_Location_LocationId",
                table: "UserLocationAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStatuses_Location_LocationId",
                table: "UsersStatuses");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_UsersStatuses_LocationId",
                table: "UsersStatuses");

            migrationBuilder.DropIndex(
                name: "IX_UserLocationAssignments_LocationId",
                table: "UserLocationAssignments");
        }
    }
}
