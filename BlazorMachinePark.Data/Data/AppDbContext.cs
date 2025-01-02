﻿using BlazorMachinePark.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Data.DbContexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Sweden", EmojiFlag = "\ud83c\uddf8\ud83c\uddea" },
                new Country { Id = 2, Name = "Norway", EmojiFlag = "\ud83c\uddf3\ud83c\uddf4" },
                new Country { Id = 3, Name = "Denmark", EmojiFlag = "\ud83c\udde9\ud83c\uddf0" },
                new Country { Id = 4, Name = "Finland", EmojiFlag = "\ud83c\uddeb\ud83c\uddee" });

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Stockholm", CountryId = 1 },
                new City { Id = 2, Name = "Oslo", CountryId = 2 },
                new City { Id = 3, Name = "Copenhagen", CountryId = 3 },
                new City { Id = 4, Name = "Helsinki", CountryId = 4 },
                new City { Id = 5, Name = "Gothenburg", CountryId = 1 });

            modelBuilder.Entity<MachineType>().HasData(
                new MachineType { Id = 1, Name = "Weather Sensor", Description = "temperature, humidity" },
                new MachineType { Id = 2, Name = "Pressure Sensor", Description = "measures pressure" },
                new MachineType { Id = 3, Name = "Vibration Sensor", Description = "detects vibrations" });

            var now = DateTime.UtcNow;
            modelBuilder.Entity<Machine>().HasData(
                new Machine
                {
                    IsRunning = true,
                    CityId = 1, // Stockholm
                    MachineTypeId = 1, // Weather Sensor
                    CreatedAt = now,
                    UpdatedAt = now,
                    Longitude = 18.05,
                    Latitude = 59.325,
                },
                new Machine
                {
                    IsRunning = false,
                    CityId = 2, // Oslo
                    MachineTypeId = 2, // Pressure Sensor
                    CreatedAt = now,
                    UpdatedAt = now,
                    Longitude = 10.74609,
                    Latitude = 59.91273,
                },
                new Machine
                {
                    IsRunning = true,
                    CityId = 3, // Copenhagen
                    MachineTypeId = 3, // Vibration Sensor
                    CreatedAt = now,
                    UpdatedAt = now,
                    Longitude = 12.568337,
                    Latitude = 55.676098
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimeStamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimeStamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ITimeStamped &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var now = DateTime.UtcNow;

                var timeStampedEntity = (ITimeStamped)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    timeStampedEntity.CreatedAt = now;
                }

                timeStampedEntity.UpdatedAt = now;
            }
        }

    }
}