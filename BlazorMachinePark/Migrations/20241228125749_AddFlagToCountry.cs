using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorMachinePark.Migrations
{
    /// <inheritdoc />
    public partial class AddFlagToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("76c159e5-9c0e-44e4-9a8e-1732132cefca"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("c4d8fc65-de98-494a-9e15-c04c760e81be"));

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: new Guid("f673b536-bff2-4ada-a60e-92342fa871c1"));

            migrationBuilder.AddColumn<string>(
                name: "EmojiFlag",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmojiFlag",
                value: "🇸🇪");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmojiFlag",
                value: "🇳🇴");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmojiFlag",
                value: "🇩🇰");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmojiFlag",
                value: "🇫🇮");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EmojiFlag",
                table: "Countries");

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "CityId", "IsRunning", "MachineTypeId" },
                values: new object[,]
                {
                    { new Guid("76c159e5-9c0e-44e4-9a8e-1732132cefca"), 2, false, 2 },
                    { new Guid("c4d8fc65-de98-494a-9e15-c04c760e81be"), 3, true, 3 },
                    { new Guid("f673b536-bff2-4ada-a60e-92342fa871c1"), 1, true, 1 }
                });
        }
    }
}
