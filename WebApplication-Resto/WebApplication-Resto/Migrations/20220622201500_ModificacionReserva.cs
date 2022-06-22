using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_Resto.Migrations
{
    public partial class ModificacionReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraReserva",
                table: "RegistroReservas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaR",
                table: "RegistroReservas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaReserva",
                table: "RegistroReservas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaR",
                table: "RegistroReservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaReserva",
                table: "RegistroReservas",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "HoraReserva",
                table: "RegistroReservas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
