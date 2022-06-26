using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_Resto.Migrations
{
    public partial class CrearRestoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comensales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    NroCelular = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comensales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComensal = table.Column<int>(nullable: false),
                    ApellidoTitular = table.Column<string>(maxLength: 30, nullable: false),
                    DniTitular = table.Column<int>(nullable: false),
                    EstadoR = table.Column<int>(nullable: false),
                    CantComensales = table.Column<int>(nullable: false),
                    FechaReserva = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EstadoReserva = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comensales");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
