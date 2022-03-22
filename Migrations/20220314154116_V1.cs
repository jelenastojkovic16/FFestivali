using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_PROJEKAT.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivali",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivFestivala = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivali", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UkupnaCena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DnevniRepertoari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    Dan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FestivalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevniRepertoari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DnevniRepertoari_Festivali_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festivali",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivFilma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImeReditelja = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    DanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Filmovi_DnevniRepertoari_DanID",
                        column: x => x.DanID,
                        principalTable: "DnevniRepertoari",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojUlaznica = table.Column<int>(type: "int", nullable: false),
                    DanID = table.Column<int>(type: "int", nullable: true),
                    RezervacijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Karte_DnevniRepertoari_DanID",
                        column: x => x.DanID,
                        principalTable: "DnevniRepertoari",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karte_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DnevniRepertoari_FestivalID",
                table: "DnevniRepertoari",
                column: "FestivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_DanID",
                table: "Filmovi",
                column: "DanID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_DanID",
                table: "Karte",
                column: "DanID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_RezervacijaID",
                table: "Karte",
                column: "RezervacijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmovi");

            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "DnevniRepertoari");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Festivali");
        }
    }
}
