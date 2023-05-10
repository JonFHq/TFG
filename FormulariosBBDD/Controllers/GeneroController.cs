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
    public class GeneroController : Controller
    {
        private readonly Context _context;

        public GeneroController(Context context)
        {
            _context = context;
        }

        // GET: Genero
        public async Task<IActionResult> Index()
        {
              return _context.Generos != null ? 
                          View(await _context.Generos.ToListAsync()) :
                          Problem("Entity set 'Context.Generos'  is null.");
        }

        // GET: Genero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Generos == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (generoModel == null)
            {
                return NotFound();
            }

            return View(generoModel);
        }

        // GET: Genero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Genero")] GeneroModel generoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generoModel);
        }

        // GET: Genero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Generos == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos.FindAsync(id);
            if (generoModel == null)
            {
                return NotFound();
            }
            return View(generoModel);
        }

        // POST: Genero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Genero")] GeneroModel generoModel)
        {
            if (id != generoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroModelExists(generoModel.ID))
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
            return View(generoModel);
        }

        // GET: Genero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Generos == null)
            {
                return NotFound();
            }

            var generoModel = await _context.Generos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (generoModel == null)
            {
                return NotFound();
            }

            return View(generoModel);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Generos == null)
            {
                return Problem("Entity set 'Context.Generos'  is null.");
            }
            var generoModel = await _context.Generos.FindAsync(id);
            if (generoModel != null)
            {
                _context.Generos.Remove(generoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroModelExists(int id)
        {
          return (_context.Generos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
