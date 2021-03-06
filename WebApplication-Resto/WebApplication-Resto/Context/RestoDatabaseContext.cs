
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
            optionsBuilder.UseSqlServer("Server=DESKTOP-V5NCH6A;Database=RestauranteDB;Trusted_Connection=True;");
        }

        public DbSet<Comensal> Comensales { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        //public DbSet<WebApplication_Resto.Models.Reserva> ReservaS { get; set; }
        public object Comensal { get; internal set; }
    }
}
