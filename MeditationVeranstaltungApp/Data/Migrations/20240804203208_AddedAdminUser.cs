using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28aaaaad-012d-4951-b501-5813b2a541ff", null, "Admin", "ADMIN" },
                    { "a609455d-5f11-42bd-be9d-5fd66e4570c0", null, "User", "USER" },
                    { "b2b71169-bcf7-41c6-90c5-3f808fd7cafa", null, "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e", 0, "6d6fda50-588b-431b-a501-98d80685af75", "admin@web.de", false, false, null, "ADMIN@WEB.DE", "ADMIN@WEB.DE", "AQAAAAIAAYagAAAAEEQR7xQcJuQdP8l0bZBzlDI/ELNPSsNr2kUZUWwepWHpz698gzqmQqmwvhUwxr+qyQ==", null, false, "439a8332-79a6-48f0-bf17-9ae548b20b31", false, "admin@web.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28aaaaad-012d-4951-b501-5813b2a541ff", "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a609455d-5f11-42bd-be9d-5fd66e4570c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2b71169-bcf7-41c6-90c5-3f808fd7cafa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28aaaaad-012d-4951-b501-5813b2a541ff", "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28aaaaad-012d-4951-b501-5813b2a541ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e");
        }
    }
}
