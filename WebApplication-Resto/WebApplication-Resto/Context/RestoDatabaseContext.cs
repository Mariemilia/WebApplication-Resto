
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Resto.Models;

namespace WebApplication_Resto.Models
{
    public class RestoDatabaseContext : DbContext

    {
        public RestoDatabaseContext()
        {
        }
        public RestoDatabaseContext(DbContextOptions<RestoDatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FK65H1A;Database=RestauranteDB;Trusted_Connection=True;");
        }

        public DbSet<Comensal> Comensales { get; set; }
        public DbSet<Reserva> RegistroReservas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<WebApplication_Resto.Models.ReservaHecha> ReservaHecha { get; set; }
    }
}
