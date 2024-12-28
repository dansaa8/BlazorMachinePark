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
                    { new Guid("9ab398a3-8b15-4295-8b4b-9f9c99719f51"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a007fa92-abd6-4122-858c-87d9401fc2ed"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da1bba3a-ce1b-480d-b05e-b477249c168f"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("9ab398a3-8b15-4295-8b4b-9f9c99719f51"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("a007fa92-abd6-4122-858c-87d9401fc2ed"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("da1bba3a-ce1b-480d-b05e-b477249c168f"));

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
