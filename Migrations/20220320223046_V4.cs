using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_PROJEKAT.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sediste",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrojMesta",
                table: "DnevniRepertoari",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sediste",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "BrojMesta",
                table: "DnevniRepertoari");
        }
    }
}
