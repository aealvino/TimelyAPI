using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
