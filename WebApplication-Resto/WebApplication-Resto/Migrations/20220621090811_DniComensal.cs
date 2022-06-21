using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_Resto.Migrations
{
    public partial class DniComensal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdComensal",
                table: "Comensales");

            migrationBuilder.AddColumn<int>(
                name: "Dni",
                table: "Comensales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Comensales");

            migrationBuilder.AddColumn<int>(
                name: "IdComensal",
                table: "Comensales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
