using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace topcoderattempt1.Migrations.Mercury
{
    public partial class CreatedBaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 10, nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    DeviceName_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSpaceAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSpaceAssignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmailChangeRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RequestedOn = table.Column<DateTime>(nullable: false),
                    VerificationToken = table.Column<string>(maxLength: 45, nullable: true),
                    VerificationTokenExpiry = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailChangeRequests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KeyholderDeviceAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyholderId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    KeyDevicePermissionId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    SpaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyholderDeviceAssignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Keyholders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    KeySerialNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    State = table.Column<int>(nullable: true),
                    Pin = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyholders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KeyholderSpaceAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyHolderId = table.Column<int>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyholderSpaceAssignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KeyholderStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyholderStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ActivityText = table.Column<string>(maxLength: 250, nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    ActvityTime = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserKeyMaps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    KetSerialNumber = table.Column<string>(maxLength: 10, nullable: true),
                    AppliedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKeyMaps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserLocationAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsToolKitEnabled = table.Column<bool>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    LastUpdateBy = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    DisabledReason = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocationAssignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLocationID = table.Column<int>(nullable: false),
                    HasAdminRead = table.Column<bool>(nullable: true),
                    HasAdminEdit = table.Column<bool>(nullable: true),
                    HasKeyholderRead = table.Column<bool>(nullable: true),
                    HasKeyholderEdit = table.Column<bool>(nullable: true),
                    HasDeviceRead = table.Column<bool>(nullable: true),
                    HasDeviceEdit = table.Column<bool>(nullable: true),
                    HasSpaceRead = table.Column<bool>(nullable: true),
                    HasSpaceEdit = table.Column<bool>(nullable: true),
                    HasConfigRead = table.Column<bool>(nullable: true),
                    HasConfigEdit = table.Column<bool>(nullable: true),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Isdefualt = table.Column<bool>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersStatuses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceSpaceAssignments");

            migrationBuilder.DropTable(
                name: "DeviceStatuses");

            migrationBuilder.DropTable(
                name: "EmailChangeRequests");

            migrationBuilder.DropTable(
                name: "KeyholderDeviceAssignments");

            migrationBuilder.DropTable(
                name: "Keyholders");

            migrationBuilder.DropTable(
                name: "KeyholderSpaceAssignments");

            migrationBuilder.DropTable(
                name: "KeyholderStatuses");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "UserKeyMaps");

            migrationBuilder.DropTable(
                name: "UserLocationAssignments");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UsersStatuses");
        }
    }
}
