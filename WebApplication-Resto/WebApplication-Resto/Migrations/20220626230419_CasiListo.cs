using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_Resto.Migrations
{
    public partial class CasiListo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "EstadoReserva",
                table: "Reservas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstadoReserva",
                table: "Reservas",
                type: "int",
                nullable: true);
        }
    }
}
