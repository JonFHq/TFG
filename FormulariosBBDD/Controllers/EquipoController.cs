using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormulariosBBDD.Models;

namespace FormulariosBBDD.Controllers
{
    public class EquipoController : Controller
    {
        private readonly Context _context;

        public EquipoController(Context context)
        {
            _context = context;
        }

        // GET: Equipo
        public async Task<IActionResult> Index()
        {
            _context.updateAll();
            return _context.Equipos != null ? 
                          View(await _context.Equipos.ToListAsync()) :
                          Problem("Entity set 'Context.Equipos'  is null.");
        }

        // GET: Equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipoModel = await _context.Equipos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (equipoModel == null)
            {
                return NotFound();
            }

            return View(equipoModel);
        }

        // GET: Equipo/Create
        public IActionResult Create()
        {
            _context.updateAll();
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Equipo")] EquipoModel equipoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoModel);
        }

        // GET: Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipoModel = await _context.Equipos.FindAsync(id);
            if (equipoModel == null)
            {
                return NotFound();
            }
            return View(equipoModel);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Equipo")] EquipoModel equipoModel)
        {
            if (id != equipoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoModelExists(equipoModel.ID))
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
            return View(equipoModel);
        }

        // GET: Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipoModel = await _context.Equipos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (equipoModel == null)
            {
                return NotFound();
            }

            return View(equipoModel);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipos == null)
            {
                return Problem("Entity set 'Context.Equipos'  is null.");
            }
            var equipoModel = await _context.Equipos.FindAsync(id);
            if (equipoModel != null)
            {
                _context.Equipos.Remove(equipoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoModelExists(int id)
        {
          return (_context.Equipos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
