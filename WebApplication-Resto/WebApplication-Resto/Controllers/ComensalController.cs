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
    public class ComensalController : Controller
    {
        private readonly RestoDatabaseContext _context;

        public ComensalController(RestoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Comensal
        public async Task<IActionResult> Index(string searching = "", int pg = 1)
        {
            List<Comensal> data2 = _context.Comensales.ToList();
            if (!string.IsNullOrEmpty(searching))
            {
                data2 = await _context.Comensales.Where(x => x.Apellido.Contains(searching) || x.Dni.ToString().Contains(searching) || searching == null).ToListAsync();

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
            //return View(await _context.Comensales.ToListAsync());
        }

        // GET: Comensal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comensal = await _context.Comensales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comensal == null)
            {
                return NotFound();
            }

            return View(comensal);
        }

        // GET: Comensal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comensal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apellido,Dni,NroCelular,Email")] Comensal comensal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comensal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comensal);
        }

        // GET: Comensal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comensal = await _context.Comensales.FindAsync(id);
            if (comensal == null)
            {
                return NotFound();
            }
            return View(comensal);
        }

        // POST: Comensal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apellido,Dni,NroCelular,Email")] Comensal comensal)
        {
            if (id != comensal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comensal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComensalExists(comensal.Id))
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
            return View(comensal);
        }

        // GET: Comensal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comensal = await _context.Comensales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comensal == null)
            {
                return NotFound();
            }

            return View(comensal);
        }

        // POST: Comensal/Delete/5
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comensal = await _context.Comensales.FindAsync(id);
            _context.Comensales.Remove(comensal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComensalExists(int id)
        {
            return _context.Comensales.Any(e => e.Id == id);
        }
    }
}
