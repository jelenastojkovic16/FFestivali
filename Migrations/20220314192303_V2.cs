using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_PROJEKAT.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpisFestivala",
                table: "Festivali",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisFestivala",
                table: "Festivali");
        }
    }
}
