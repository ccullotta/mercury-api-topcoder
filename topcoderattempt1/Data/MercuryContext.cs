using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Models;

namespace topcoderattempt1.Data
{
    public class MercuryContext : DbContext
    {
        public MercuryContext(DbContextOptions<MercuryContext> opt) : base(opt)
        {
                
        }


        public DbSet<UserModel> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceSpace> DeviceSpaceAssignments { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<Keyholder> Keyholders { get; set; }
        public DbSet<KeyholderDevice> KeyholderDeviceAssignments { get; set; }
        public DbSet<KeyholderSpace> KeyholderSpaceAssignments { get; set; }
        public DbSet<KeyholderStatus> KeyholderStatuses { get; set; }
        public DbSet<ChangeEmailRequest> EmailChangeRequests { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserKeyMapping> UserKeyMaps { get; set; }
        public DbSet<UserLocation> UserLocationAssignments { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserStatus> UsersStatuses { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLocation>()
                .HasOne(x => x.UserModel)
                .WithMany(y => y.UserLocations)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(x => x.UserKeyMappings)
                .WithOne(y => y.User);

            modelBuilder.Entity<UserLocation>()
                .HasOne(x => x.UserPermission)
                .WithOne(y => y.UserLocation)
                .HasForeignKey<UserPermission>(x => x.UserLocationID);

            modelBuilder.Entity<UserLocation>()
                .HasOne(x => x.Status)
                .WithOne(x => x.UserLocation)
                .HasPrincipalKey<UserLocation>(x => x.StatusId);

            modelBuilder.Entity<Location>()
                .HasMany(x => x.UserLocations)
                .WithOne(y => y.Location);
            //.HasForeignKey(x => x.LocationId); not neccessary because we follow convention
            modelBuilder.Entity<Location>()
                .HasMany(x => x.UserKeyMappings)
                .WithOne(y => y.Location);

            modelBuilder.Entity<UserKeyMapping>()
                .HasOne(x => x.Keyholder)
                .WithOne(x => x.UserKeyMapping)
                .HasForeignKey<Keyholder>(x => x.KeySerialNumber)
                .HasPrincipalKey<UserKeyMapping>(x=>x.KeySerialNumber);

            modelBuilder.Entity<ChangeEmailRequest>()
                .HasOne(x => x.User)
                .WithMany(x => x.ChangeEmailRequests);

            modelBuilder.Entity<UserActivity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserActivities);

        }

    }

}
