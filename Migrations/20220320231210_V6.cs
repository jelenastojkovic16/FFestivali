using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_PROJEKAT.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sediste",
                table: "Rezervacije");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sediste",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
