using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPickUpsAndAnzahlWeiblich : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnzahlWeiblich",
                table: "ReiseInfos",
                newName: "AnzahlFrauen");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0883c90b-f4ce-466a-b581-a4656b78a66f", "AQAAAAIAAYagAAAAEKfqzOr+s4svVZKpYOJJgFbHp89C/6uC34JEo3dw4ygHIRYm08nQ85kGTKpDmWufLg==", "333b4900-18f9-482b-9777-70a1513544c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnzahlFrauen",
                table: "ReiseInfos",
                newName: "AnzahlWeiblich");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eee3b51-4067-408e-b1b6-65f4d89d8919", "AQAAAAIAAYagAAAAEP+46y/Y+mEpDms8UmHXpiT1ll5YpLZa1pFvridifBKoNxGF9q3Cj8WT1fuFll5U+A==", "ce5d28c9-25be-464c-af32-9a40446f188b" });
        }
    }
}
