using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
