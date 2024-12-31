﻿// <auto-generated />
using System;
using BlazorMachinePark.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorMachinePark.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 4,
                            Name = "Helsinki"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 1,
                            Name = "Gothenburg"
                        });
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmojiFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmojiFlag = "🇸🇪",
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            EmojiFlag = "🇳🇴",
                            Name = "Norway"
                        },
                        new
                        {
                            Id = 3,
                            EmojiFlag = "🇩🇰",
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 4,
                            EmojiFlag = "🇫🇮",
                            Name = "Finland"
                        });
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af118676-620a-446d-9edf-8fb3cc2d808e"),
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156),
                            IsRunning = true,
                            Latitude = 59.325000000000003,
                            Longitude = 18.050000000000001,
                            MachineTypeId = 1,
                            UpdatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156)
                        },
                        new
                        {
                            Id = new Guid("829cd080-d248-4443-8f1c-c1025bb119fd"),
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156),
                            IsRunning = false,
                            Latitude = 59.912730000000003,
                            Longitude = 10.746090000000001,
                            MachineTypeId = 2,
                            UpdatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156)
                        },
                        new
                        {
                            Id = new Guid("acc6df72-2dae-484c-9fbd-a0536275cd69"),
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156),
                            IsRunning = true,
                            Latitude = 55.676098000000003,
                            Longitude = 12.568337,
                            MachineTypeId = 3,
                            UpdatedAt = new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156)
                        });
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.MachineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MachineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "temperature, humidity",
                            Name = "Weather Sensor"
                        },
                        new
                        {
                            Id = 2,
                            Description = "measures pressure",
                            Name = "Pressure Sensor"
                        },
                        new
                        {
                            Id = 3,
                            Description = "detects vibrations",
                            Name = "Vibration Sensor"
                        });
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.City", b =>
                {
                    b.HasOne("BlazorMachinePark.Shared.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.Machine", b =>
                {
                    b.HasOne("BlazorMachinePark.Shared.Entities.City", "City")
                        .WithMany("Machines")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorMachinePark.Shared.Entities.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.City", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Entities.MachineType", b =>
                {
                    b.Navigation("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}
