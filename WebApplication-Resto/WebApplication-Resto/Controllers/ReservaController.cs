using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Resto.Models;

namespace WebApplication_Resto.Controllers
{
    public class ReservaController : Controller
    {
        private readonly RestoDatabaseContext _context;

        public ReservaController(RestoDatabaseContext context)
        {
            _context = context;
        }
        // GET: Reserva
        public async Task<IActionResult> Index(string searching= "", int pg = 1)
        {
            var data2 = _context.Reservas.ToList();
            if (!string.IsNullOrEmpty(searching))
            {
                data2 = await _context.Reservas.Where(x => x.ApellidoTitular.Contains(searching) || x.DniTitular.ToString().Contains(searching)).ToListAsync();

            }
            const int pageSize = 3;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = data2.Count();
            var paginado = new Paginado(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            data2 = data2.Skip(recSkip).Take(paginado.PageSize).ToList();
            ViewBag.Paginado = paginado;
            ViewBag.CurrentSearching = searching;
            return View(data2);
            //return View(await _context.Reservas.Where(x => x.DniTitular.Contains(searching) || x.ApellidoTitular.ToString().Contains(searching) || searching == null).ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,ApellidoTitular,DniTitular,CantComensales,FechaReserva,EstadoR")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,ApellidoTitular,DniTitular,CantComensales,FechaReserva,EstadoR")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
