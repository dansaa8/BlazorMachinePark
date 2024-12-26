using BlazorMachinePark.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<City> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Sweden" },
                new Country { Id = 2, Name = "Norway" },
                new Country { Id = 3, Name = "Denmark" },
                new Country { Id = 4, Name = "Finland" });

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

            modelBuilder.Entity<Machine>().HasData(
                new Machine
                {
                    IsRunning = true,
                    CityId = 1, // Stockholm
                    MachineTypeId = 1 // Weather Sensor
                },
                new Machine
                {
                    IsRunning = false,
                    CityId = 2, // Oslo
                    MachineTypeId = 2 // Pressure Sensor
                },
                new Machine
                {
                    IsRunning = true,
                    CityId = 3, // Copenhagen
                    MachineTypeId = 3 // Vibration Sensor
                });

        }
    }
}
