﻿// <auto-generated />
using System;
using BlazorMachinePark.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorMachinePark.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241228125749_AddFlagToCountry")]
    partial class AddFlagToCountry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.City", b =>
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

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.Country", b =>
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

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("bit");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("572e5c6a-86ec-4138-af39-5cfeebad250c"),
                            CityId = 1,
                            IsRunning = true,
                            MachineTypeId = 1
                        },
                        new
                        {
                            Id = new Guid("3558b313-762f-48ff-99b7-a46267b507f5"),
                            CityId = 2,
                            IsRunning = false,
                            MachineTypeId = 2
                        },
                        new
                        {
                            Id = new Guid("5a7103bf-a244-45f4-a5d0-e31a09739e9c"),
                            CityId = 3,
                            IsRunning = true,
                            MachineTypeId = 3
                        });
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.MachineType", b =>
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

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.City", b =>
                {
                    b.HasOne("BlazorMachinePark.Shared.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.Machine", b =>
                {
                    b.HasOne("BlazorMachinePark.Shared.Domain.City", "City")
                        .WithMany("Machines")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorMachinePark.Shared.Domain.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.City", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("BlazorMachinePark.Shared.Domain.MachineType", b =>
                {
                    b.Navigation("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}
