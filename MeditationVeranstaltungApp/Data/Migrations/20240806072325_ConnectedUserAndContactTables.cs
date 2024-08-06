using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConnectedUserAndContactTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Kontakts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad05cf07-74ae-4438-b3f7-730b9a9d8555", "AQAAAAIAAYagAAAAEBQSxw2HEpPjBNFZpNf8n4wPxkrKHOKHOqg2pVqOaSLo6thsM/lsmoKLe5da4xdOUA==", "3107db1b-6e98-4831-be59-1e8b4ccd9f0e" });

            migrationBuilder.CreateIndex(
                name: "IX_Kontakts_UserId",
                table: "Kontakts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakts_AspNetUsers_UserId",
                table: "Kontakts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakts_AspNetUsers_UserId",
                table: "Kontakts");

            migrationBuilder.DropIndex(
                name: "IX_Kontakts_UserId",
                table: "Kontakts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Kontakts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7291578-bf77-4d5d-8ac3-51f4160c3350", "AQAAAAIAAYagAAAAEMudGYauduB/hpLiiip4+Dci37BKr4/5+HX3R83yMejI63URLAVSplNm54v8KrIJQQ==", "ff8a806c-54e7-4403-a7f1-e53c161130f1" });
        }
    }
}
