﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_Resto.Models;

namespace WebApplication_Resto.Migrations
{
    [DbContext(typeof(RestoDatabaseContext))]
    partial class RestoDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication_Resto.Models.Comensal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("NroCelular")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comensales");
                });

            modelBuilder.Entity("WebApplication_Resto.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CantComensales")
                        .HasColumnType("int");

                    b.Property<int>("DniTitular")
                        .HasColumnType("int");

                    b.Property<int>("EstadoR")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdComensal")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.ToTable("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
