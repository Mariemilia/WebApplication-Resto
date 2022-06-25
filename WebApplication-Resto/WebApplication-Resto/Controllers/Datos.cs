using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication_Resto.Models;

namespace WebApplication_Resto.Controllers
{
    public class Datos : Controller
    {
        private readonly RestoDatabaseContext _context;

        public Datos(RestoDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["CantidadReservas"] = _context.ReservaHecha.Count();
            ViewData["CantidadComensales"] = _context.Comensales.Count();
            
            var data = _context.ReservaHecha.GroupBy(info => info.IdComensal)
                        .Select(group => new
                        {
                            Metric = group.Key,
                            CantidadReservas = group.Count()

                        });

            var qs = (from rh in data
                      join com in _context.Comensales on rh.Metric equals com.Id into comApellido
                      from comensalesApellidos in comApellido.DefaultIfEmpty()
                      select new { rh.CantidadReservas, comensalesApellidos.Apellido, }).ToList();

            var qsOrdeer = from s in qs
                           orderby s.CantidadReservas descending
                           select s;


            ViewBag.ReservasCompletas = qsOrdeer;
            ViewData["ReservasCompletas"] = qsOrdeer;

            return View();
            
        }
    }
}
