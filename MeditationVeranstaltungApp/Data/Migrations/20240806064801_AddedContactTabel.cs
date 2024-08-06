using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anrede = table.Column<int>(type: "int", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stadt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7291578-bf77-4d5d-8ac3-51f4160c3350", "AQAAAAIAAYagAAAAEMudGYauduB/hpLiiip4+Dci37BKr4/5+HX3R83yMejI63URLAVSplNm54v8KrIJQQ==", "ff8a806c-54e7-4403-a7f1-e53c161130f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d6fda50-588b-431b-a501-98d80685af75", "AQAAAAIAAYagAAAAEEQR7xQcJuQdP8l0bZBzlDI/ELNPSsNr2kUZUWwepWHpz698gzqmQqmwvhUwxr+qyQ==", "439a8332-79a6-48f0-bf17-9ae548b20b31" });
        }
    }
}
