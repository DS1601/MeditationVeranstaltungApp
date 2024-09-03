using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TravelMittelNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abfahrtsmittelnummer",
                table: "ReiseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ankunftsmittelnummer",
                table: "ReiseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2887ddcc-1889-490c-b7b9-f4cdc14cdedf", "AQAAAAIAAYagAAAAEPKRrBlBegDcfsk9k2MJd0jC1sWmZiqzs+1a3KB2doIevonmnrNPn1owNZZl9vMGfw==", "e1d7e856-304b-4645-9a85-20bbc3605b5b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abfahrtsmittelnummer",
                table: "ReiseInfos");

            migrationBuilder.DropColumn(
                name: "Ankunftsmittelnummer",
                table: "ReiseInfos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0883c90b-f4ce-466a-b581-a4656b78a66f", "AQAAAAIAAYagAAAAEKfqzOr+s4svVZKpYOJJgFbHp89C/6uC34JEo3dw4ygHIRYm08nQ85kGTKpDmWufLg==", "333b4900-18f9-482b-9777-70a1513544c4" });
        }
    }
}
