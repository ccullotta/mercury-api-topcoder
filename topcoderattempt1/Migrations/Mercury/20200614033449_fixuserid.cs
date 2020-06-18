using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class fixuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Users");
        }
    }
}
