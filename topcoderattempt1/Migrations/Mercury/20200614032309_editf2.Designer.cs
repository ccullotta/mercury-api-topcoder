﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using topcoderattempt1.Data;

namespace topcoderattempt1.Migrations.Mercury
{
    [DbContext(typeof(MercuryContext))]
    [Migration("20200614032309_editf2")]
    partial class editf2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("topcoderattempt1.Models.ChangeEmailRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<DateTime?>("VerificationTokenExpiry")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("EmailChangeRequests");
                });

            modelBuilder.Entity("topcoderattempt1.Models.Device", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceName_ID")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("topcoderattempt1.Models.DeviceSpace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DeviceSpaceAssignments");
                });

            modelBuilder.Entity("topcoderattempt1.Models.DeviceStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int?>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DeviceStatuses");
                });

            modelBuilder.Entity("topcoderattempt1.Models.Keyholder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeySerialNumber")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Keyholders");
                });

            modelBuilder.Entity("topcoderattempt1.Models.KeyholderDevice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("KeyDevicePermissionId")
                        .HasColumnType("int");

                    b.Property<int>("KeyholderId")
                        .HasColumnType("int");

                    b.Property<int?>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KeyholderDeviceAssignments");
                });

            modelBuilder.Entity("topcoderattempt1.Models.KeyholderSpace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KeyHolderId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KeyholderSpaceAssignments");
                });

            modelBuilder.Entity("topcoderattempt1.Models.KeyholderStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int?>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("KeyholderStatuses");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityText")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<byte[]>("ActvityTime")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserActivities");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserKeyMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppliedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("KetSerialNumber")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserKeyMaps");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisabledReason")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsToolKitEnabled")
                        .HasColumnType("bit");

                    b.Property<int?>("LastUpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("UserLocationAssignments");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserModel", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTemporaryPassword")
                        .HasColumnType("bit");

                    b.Property<int?>("LastUpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SecurityQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SecurityQuestionAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<DateTime?>("VerificationTokenExpiry")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserPermission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("HasAdminEdit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasAdminRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasConfigEdit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasConfigRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasDeviceEdit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasDeviceRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasKeyholderEdit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasKeyholderRead")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasSpaceEdit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasSpaceRead")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("locationId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("locationId")
                        .IsUnique();

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Isdefualt")
                        .HasColumnType("bit");

                    b.Property<int?>("LastUpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("UsersStatuses");
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserLocation", b =>
                {
                    b.HasOne("topcoderattempt1.Models.UserModel", "UserModel")
                        .WithMany("UserLocations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("topcoderattempt1.Models.UserPermission", b =>
                {
                    b.HasOne("topcoderattempt1.Models.UserLocation", "UserLocation")
                        .WithOne("UserPermission")
                        .HasForeignKey("topcoderattempt1.Models.UserPermission", "locationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
