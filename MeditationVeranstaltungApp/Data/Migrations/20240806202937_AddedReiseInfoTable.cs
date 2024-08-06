using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeditationVeranstaltungApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedReiseInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReiseInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Veranstalltung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnzahlMaenner = table.Column<int>(type: "int", nullable: false),
                    AnzahlWeiblich = table.Column<int>(type: "int", nullable: false),
                    AnkunftAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnkunftOrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbfahrtAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbfahrtOrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbgesagtAm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AbsageGrund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notiz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FahrerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReiseInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReiseInfos_AspNetUsers_FahrerId",
                        column: x => x.FahrerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReiseInfos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eee3b51-4067-408e-b1b6-65f4d89d8919", "AQAAAAIAAYagAAAAEP+46y/Y+mEpDms8UmHXpiT1ll5YpLZa1pFvridifBKoNxGF9q3Cj8WT1fuFll5U+A==", "ce5d28c9-25be-464c-af32-9a40446f188b" });

            migrationBuilder.CreateIndex(
                name: "IX_ReiseInfos_FahrerId",
                table: "ReiseInfos",
                column: "FahrerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReiseInfos_UserId",
                table: "ReiseInfos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReiseInfos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad05cf07-74ae-4438-b3f7-730b9a9d8555", "AQAAAAIAAYagAAAAEBQSxw2HEpPjBNFZpNf8n4wPxkrKHOKHOqg2pVqOaSLo6thsM/lsmoKLe5da4xdOUA==", "3107db1b-6e98-4831-be59-1e8b4ccd9f0e" });
        }
    }
}
