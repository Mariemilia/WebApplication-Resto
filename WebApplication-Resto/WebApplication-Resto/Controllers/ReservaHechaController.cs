using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_Resto.Models;

namespace WebApplication_Resto.Controllers
{
    public class ReservaHechaController : Controller
    {
        private readonly RestoDatabaseContext _context;

        public ReservaHechaController(RestoDatabaseContext context)
        {
            _context = context;
        }

        // GET: ReservaHecha
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaHecha.ToListAsync());
        }

        // GET: ReservaHecha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHecha = await _context.ReservaHecha
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaHecha == null)
            {
                return NotFound();
            }

            return View(reservaHecha);
        }

        // GET: ReservaHecha/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservaHecha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DniTitular,FechaR,EstadoR,IdReserva,IdComensal,ApellidoTitular,CantComensales,FechaReserva")] ReservaHecha reservaHecha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaHecha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaHecha);
        }

        // GET: ReservaHecha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHecha = await _context.ReservaHecha.FindAsync(id);
            if (reservaHecha == null)
            {
                return NotFound();
            }
            return View(reservaHecha);
        }

        // POST: ReservaHecha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DniTitular,FechaR,EstadoR,IdReserva,IdComensal,ApellidoTitular,CantComensales,FechaReserva")] ReservaHecha reservaHecha)
        {
            if (id != reservaHecha.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaHecha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaHechaExists(reservaHecha.IdReserva))
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
            return View(reservaHecha);
        }

        // GET: ReservaHecha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHecha = await _context.ReservaHecha
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaHecha == null)
            {
                return NotFound();
            }

            return View(reservaHecha);
        }

        // POST: ReservaHecha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaHecha = await _context.ReservaHecha.FindAsync(id);
            _context.ReservaHecha.Remove(reservaHecha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaHechaExists(int id)
        {
            return _context.ReservaHecha.Any(e => e.IdReserva == id);
        }
    }
}
