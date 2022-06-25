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

        public async Task<IActionResult> Index(string searching = "", int pg = 1)
        {

            var data2 = _context.ReservaHecha.ToList();
            if (!string.IsNullOrEmpty(searching))
            {
                data2 = await _context.ReservaHecha.Where(x => x.DniTitular.ToString().Contains(searching) || searching == null).ToListAsync();

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

            //return View(await _context.ReservaHecha.ToListAsync());
        }

        // GET: ReservaHecha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHecha = await _context.ReservaHecha
                .FirstOrDefaultAsync(r => r.IdComensal == id);
            if (reservaHecha == null)
            {
                return NotFound();
            }

            return View(reservaHecha);
        }

        // GET: ReservaHecha/Create

        public IActionResult Create(bool esValido = false)
        {
            List<SelectListItem> ComensalItems = new List<SelectListItem>();
            foreach (Comensal c in _context.Comensales)
            {
                ComensalItems.Add(new SelectListItem()
                {
                    Text = c.Apellido.ToString() + " " + c.Dni.ToString() + " " + c.NroCelular.ToString() + " " + c.Email.ToString(), // + " -    Estado de la reserva: " + r.EstadoR.ToString(),

                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.ComensalItems = ComensalItems;
            ViewBag.EsValido = esValido;

            return View();
        }
        /*public IActionResult Create()
        {
            return View();
        }*/

        // POST: ReservaHecha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DniTitular,FechaR,EstadoR,IdReserva,IdComensal,ApellidoTitular,CantComensales,FechaReserva,IdReserva,ApellidoTitular,EstadoR,FechaReserva")] ReservaHecha reservaHecha)
        {
            if (ModelState.IsValid)
            {
                foreach (ReservaHecha rh in _context.ReservaHecha.Where(r => r.FechaReserva.Equals(reservaHecha.FechaReserva)))
                {
                    if (rh.IdComensal == reservaHecha.IdComensal)
                    {
                        TempData["AlertMessage"] = "Ya hay una reserva en ese día y horario.";

                        return RedirectToAction("Create", new { esValido = true });
                    }
                    else if (rh.DniTitular == reservaHecha.DniTitular)
                    {
                        TempData["AlertMessage"] = "El cliente ya hizo la reserva.";

                        return RedirectToAction("Create", new { esValido = true });
                    }
                }
                foreach (Comensal c in _context.Comensales.Where(s => s.Dni == reservaHecha.DniTitular))
                {
                    reservaHecha.IdComensal = c.Id;
                }

                _context.Add(reservaHecha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> ComensalItems = new List<SelectListItem>();

            foreach (Comensal c in _context.Comensales)
            {
                ComensalItems.Add(new SelectListItem()
                {
                    Text = c.Apellido.ToString() + " " + c.Dni.ToString() + " " + c.NroCelular.ToString() + " " + c.Email.ToString(),

                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.ComensalItems = ComensalItems;
            return View(reservaHecha);
        }
        /*if (ModelState.IsValid)
        {
            _context.Add(reservaHecha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(reservaHecha);
        }*/

        // GET: ReservaHecha/Edit/5
        public async Task<IActionResult> Edit(int? id, bool esValido = false)
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
            List<SelectListItem> ComensalItems = new List<SelectListItem>();
            foreach (Comensal c in _context.Comensales)
            {
                ComensalItems.Add(new SelectListItem()
                {
                    Text = c.Apellido.ToString() + " " + c.Dni.ToString() + " " + c.NroCelular.ToString() + " " + c.Email.ToString(),//-    Especialidad: " + m.Especialidad.ToString(),

                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.ComensalItems = ComensalItems;
            ViewBag.EsValido = esValido;
            return View(reservaHecha);
        }

        // POST: ReservaHecha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComensal,ApellidoTitular,DniTitular,CantComensales,FechaReserva,EstadoR,IdReserva")] ReservaHecha reservaHecha)
        {
            if (id != reservaHecha.IdReserva)
            {
                return NotFound();
            }
            List<SelectListItem> ComensalItems = new List<SelectListItem>();
            foreach (Comensal c in _context.Comensales)
            {
                ComensalItems.Add(new SelectListItem()
                {
                    Text = c.Apellido.ToString() + " " + c.Dni.ToString() + " " + c.NroCelular.ToString() + " " + c.Email.ToString(),//" -    Especialidad: " + m.Especialidad.ToString(),

                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.ComensalItems = ComensalItems;

            if (ModelState.IsValid)
            {
                try
                {
                    DateTime date = DateTime.Today;

                    foreach (ReservaHecha rh in _context.ReservaHecha.Where(s => s.FechaReserva.Equals(reservaHecha.FechaReserva)))
                    {
                        if (rh.IdComensal == reservaHecha.IdComensal)
                        {
                            TempData["AlertMessage"] = "Ya hay una reserva en ese día y horario.";

                            return RedirectToAction("Create", new { esValido = true });
                        }
                        else if (rh.DniTitular == reservaHecha.DniTitular)
                        {
                            TempData["AlertMessage"] = "El cliente ya hizo la reserva.";

                            return RedirectToAction("Create", new { esValido = true });
                        }
                    }
                    foreach (Comensal c in _context.Comensales.Where(s => s.Dni == reservaHecha.DniTitular))
                    {
                        reservaHecha.IdComensal = c.Id;
                    }

                    _context.Update(reservaHecha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaHechaExists(reservaHecha.IdComensal))
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
            //List<SelectListItem> ComensalItems = new List<SelectListItem>();

            //  foreach (Comensal c in _context.Comensales)
            // {
            // ComensalItems.Add(new SelectListItem()
            // {
            // Text = c.Apellido.ToString() + " " + c.Dni.ToString() + " " + c.NroCelular.ToString() + " " + c.Email.ToString(),

            // Value = c.Id.ToString(),
            // Selected = false
            //});
            // }
            // ViewBag.ComensalItems = ComensalItems;
            // return View(reservaHecha);
            // }
            //  _context.Update(reservaHecha);
            // await _context.SaveChangesAsync();
        
        //  catch (DbUpdateConcurrencyException)
        // {
        //  if (!ReservaHechaExists(reservaHecha.IdReserva))
        // {
        //   return NotFound();
        //   }
        //    else
        //  {
        //     throw;
        //  }
        //  }
        //  return RedirectToAction(nameof(Index));
        // }
        // return View(reservaHecha);
        // }
    
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
        [HttpPost, ActionName("Eliminar")]
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
