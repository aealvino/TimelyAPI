using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixUsersWithNoRefreshTOken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57481398-6fdf-4011-8bdb-0fd8c63c1e6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e5e3fe6-f1fb-4831-bebe-05d7c7961923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8378290-8073-4da2-ae95-a2e0739a7852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd2deb4-085f-443a-8ab8-e06330f343d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb1f2603-eb61-4a0e-8573-3d12c6423ddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbb773ee-81d7-4ca0-9444-e9dcd91fd43c");

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
                    { "101320e0-7cc5-406f-b454-ecddff042a1e", null, "Admin", "ADMIN" },
                    { "2d438e66-35c6-4cd2-b026-e5d3a94efbaf", null, "User", "USER" },
                    { "68a7733d-9cba-4815-9b58-cebdcb4962a3", null, "Manager", "MANAGER" },
                    { "7b882da3-395a-4dc4-a6b2-eb85438f40ee", null, "Admin", "ADMIN" },
                    { "9adc2465-f716-4d2d-a061-97a856c3dbdd", null, "User", "USER" },
                    { "a91e7b16-e15e-4ce7-b5f2-2fd61290e7f8", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101320e0-7cc5-406f-b454-ecddff042a1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d438e66-35c6-4cd2-b026-e5d3a94efbaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a7733d-9cba-4815-9b58-cebdcb4962a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b882da3-395a-4dc4-a6b2-eb85438f40ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9adc2465-f716-4d2d-a061-97a856c3dbdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91e7b16-e15e-4ce7-b5f2-2fd61290e7f8");

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
                    { "57481398-6fdf-4011-8bdb-0fd8c63c1e6b", null, "Admin", "ADMIN" },
                    { "8e5e3fe6-f1fb-4831-bebe-05d7c7961923", null, "Admin", "ADMIN" },
                    { "a8378290-8073-4da2-ae95-a2e0739a7852", null, "User", "USER" },
                    { "ddd2deb4-085f-443a-8ab8-e06330f343d6", null, "Manager", "MANAGER" },
                    { "fb1f2603-eb61-4a0e-8573-3d12c6423ddc", null, "User", "USER" },
                    { "fbb773ee-81d7-4ca0-9444-e9dcd91fd43c", null, "Manager", "MANAGER" }
                });
        }
    }
}
