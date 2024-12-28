using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorMachinePark.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeStampsToMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("3558b313-762f-48ff-99b7-a46267b507f5"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("572e5c6a-86ec-4138-af39-5cfeebad250c"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("5a7103bf-a244-45f4-a5d0-e31a09739e9c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Machines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Machines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "CityId", "CreatedAt", "IsRunning", "MachineTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5359fc14-52d4-4c46-994b-09467cab7863"), 3, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460), true, 3, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460) },
                    { new Guid("7d07de2d-e797-43c1-8326-69166caa9e58"), 1, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460), true, 1, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460) },
                    { new Guid("ea0ea04b-1ece-478a-b010-3ead157838b7"), 2, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460), false, 2, new DateTime(2024, 12, 28, 14, 29, 18, 168, DateTimeKind.Utc).AddTicks(4460) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("5359fc14-52d4-4c46-994b-09467cab7863"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("7d07de2d-e797-43c1-8326-69166caa9e58"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("ea0ea04b-1ece-478a-b010-3ead157838b7"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Machines");

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "CityId", "IsRunning", "MachineTypeId" },
                values: new object[,]
                {
                    { new Guid("3558b313-762f-48ff-99b7-a46267b507f5"), 2, false, 2 },
                    { new Guid("572e5c6a-86ec-4138-af39-5cfeebad250c"), 1, true, 1 },
                    { new Guid("5a7103bf-a244-45f4-a5d0-e31a09739e9c"), 3, true, 3 }
                });
        }
    }
}
