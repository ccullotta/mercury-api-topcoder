using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: false),
                    SecurityQuestion = table.Column<string>(maxLength: 200, nullable: false),
                    SecurityQuestionAnswer = table.Column<string>(maxLength: 200, nullable: false),
                    VerificationToken = table.Column<string>(maxLength: 45, nullable: true),
                    VerificationTokenExpiry = table.Column<DateTime>(nullable: true),
                    IsEmailVerified = table.Column<bool>(nullable: true),
                    IsTemporaryPassword = table.Column<bool>(nullable: true),
                    LastUpdateBy = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
