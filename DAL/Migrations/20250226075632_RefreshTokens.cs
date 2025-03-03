using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07cc1234-8f64-40ef-b1b6-9d5c3be7316b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20a64ac9-513d-47ed-b861-fc08b3892493");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b1dd32b-7a01-4ad4-beed-a2baeeb8ab99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71523b0a-f5c7-4f41-83e0-317d32c6aaee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b988f2-5faa-453c-8e16-a7f9d8fffa90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e79e1575-e0bc-4e1b-a277-7781e491266d");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18c99fc3-e539-4f67-9fcc-ae78081f4c4d", null, "User", "USER" },
                    { "196f10b1-e51e-4080-b1b2-52fe09537a19", null, "Manager", "MANAGER" },
                    { "729ab4bc-e392-4e06-b04d-065fef66a4a9", null, "Admin", "ADMIN" },
                    { "7abb3935-787a-4cd0-9644-325492288962", null, "Manager", "MANAGER" },
                    { "94c693f1-2f9c-4cfe-a743-a9004668b4b2", null, "Admin", "ADMIN" },
                    { "d9e323b0-3484-42a1-a054-456006aaeede", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c99fc3-e539-4f67-9fcc-ae78081f4c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "196f10b1-e51e-4080-b1b2-52fe09537a19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "729ab4bc-e392-4e06-b04d-065fef66a4a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7abb3935-787a-4cd0-9644-325492288962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c693f1-2f9c-4cfe-a743-a9004668b4b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9e323b0-3484-42a1-a054-456006aaeede");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07cc1234-8f64-40ef-b1b6-9d5c3be7316b", null, "Manager", "MANAGER" },
                    { "20a64ac9-513d-47ed-b861-fc08b3892493", null, "User", "USER" },
                    { "6b1dd32b-7a01-4ad4-beed-a2baeeb8ab99", null, "Admin", "ADMIN" },
                    { "71523b0a-f5c7-4f41-83e0-317d32c6aaee", null, "User", "USER" },
                    { "72b988f2-5faa-453c-8e16-a7f9d8fffa90", null, "Manager", "MANAGER" },
                    { "e79e1575-e0bc-4e1b-a277-7781e491266d", null, "Admin", "ADMIN" }
                });
        }
    }
}
