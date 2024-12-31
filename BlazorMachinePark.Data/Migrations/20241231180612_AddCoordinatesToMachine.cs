using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorMachinePark.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinatesToMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmojiFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "EmojiFlag", "Name" },
                values: new object[,]
                {
                    { 1, "🇸🇪", "Sweden" },
                    { 2, "🇳🇴", "Norway" },
                    { 3, "🇩🇰", "Denmark" },
                    { 4, "🇫🇮", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "temperature, humidity", "Weather Sensor" },
                    { 2, "measures pressure", "Pressure Sensor" },
                    { 3, "detects vibrations", "Vibration Sensor" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Stockholm" },
                    { 2, 2, "Oslo" },
                    { 3, 3, "Copenhagen" },
                    { 4, 4, "Helsinki" },
                    { 5, 1, "Gothenburg" }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "CityId", "CreatedAt", "IsRunning", "Latitude", "Longitude", "MachineTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("829cd080-d248-4443-8f1c-c1025bb119fd"), 2, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156), false, 59.912730000000003, 10.746090000000001, 2, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156) },
                    { new Guid("acc6df72-2dae-484c-9fbd-a0536275cd69"), 3, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156), true, 55.676098000000003, 12.568337, 3, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156) },
                    { new Guid("af118676-620a-446d-9edf-8fb3cc2d808e"), 1, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156), true, 59.325000000000003, 18.050000000000001, 1, new DateTime(2024, 12, 31, 18, 6, 11, 545, DateTimeKind.Utc).AddTicks(5156) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_CityId",
                table: "Machines",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
