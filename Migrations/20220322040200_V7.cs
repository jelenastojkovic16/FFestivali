using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_PROJEKAT.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmovi_DnevniRepertoari_DanID",
                table: "Filmovi");

            migrationBuilder.DropColumn(
                name: "BrojMesta",
                table: "DnevniRepertoari");

            migrationBuilder.AlterColumn<int>(
                name: "DanID",
                table: "Filmovi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmovi_DnevniRepertoari_DanID",
                table: "Filmovi",
                column: "DanID",
                principalTable: "DnevniRepertoari",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmovi_DnevniRepertoari_DanID",
                table: "Filmovi");

            migrationBuilder.AlterColumn<int>(
                name: "DanID",
                table: "Filmovi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojMesta",
                table: "DnevniRepertoari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmovi_DnevniRepertoari_DanID",
                table: "Filmovi",
                column: "DanID",
                principalTable: "DnevniRepertoari",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
