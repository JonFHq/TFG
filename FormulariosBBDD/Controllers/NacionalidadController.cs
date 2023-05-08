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
    public class NacionalidadController : Controller
    {
        private readonly Context _context;

        public NacionalidadController(Context context)
        {
            _context = context;
        }

        // GET: Nacionalidad
        public async Task<IActionResult> Index()
        {
              return _context.Nacionalidades != null ? 
                          View(await _context.Nacionalidades.ToListAsync()) :
                          Problem("Entity set 'Context.Nacionalidades'  is null.");
        }

        // GET: Nacionalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nacionalidades == null)
            {
                return NotFound();
            }

            var nacionalidadModel = await _context.Nacionalidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nacionalidadModel == null)
            {
                return NotFound();
            }

            return View(nacionalidadModel);
        }

        // GET: Nacionalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Pais")] NacionalidadModel nacionalidadModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionalidadModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidadModel);
        }

        // GET: Nacionalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nacionalidades == null)
            {
                return NotFound();
            }

            var nacionalidadModel = await _context.Nacionalidades.FindAsync(id);
            if (nacionalidadModel == null)
            {
                return NotFound();
            }
            return View(nacionalidadModel);
        }

        // POST: Nacionalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Pais")] NacionalidadModel nacionalidadModel)
        {
            if (id != nacionalidadModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacionalidadModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadModelExists(nacionalidadModel.ID))
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
            return View(nacionalidadModel);
        }

        // GET: Nacionalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nacionalidades == null)
            {
                return NotFound();
            }

            var nacionalidadModel = await _context.Nacionalidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nacionalidadModel == null)
            {
                return NotFound();
            }

            return View(nacionalidadModel);
        }

        // POST: Nacionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nacionalidades == null)
            {
                return Problem("Entity set 'Context.Nacionalidades'  is null.");
            }
            var nacionalidadModel = await _context.Nacionalidades.FindAsync(id);
            if (nacionalidadModel != null)
            {
                _context.Nacionalidades.Remove(nacionalidadModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalidadModelExists(int id)
        {
          return (_context.Nacionalidades?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
