using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormulariosBBDD.Models;
using Microsoft.IdentityModel.Tokens;

namespace FormulariosBBDD.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly Context _context;

        public TrabajadorController(Context context)
        {
            _context = context;
        }

        // GET: Trabajador
        public async Task<IActionResult> Index()
        {
            _context.updateAll();
            var context = _context.Trabajadores.Include(t => t.Nacionalidad);
            return View(await context.ToListAsync());
        }

        // GET: Trabajador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadorModel = await _context.Trabajadores
                .Include(t => t.Nacionalidad)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trabajadorModel == null)
            {
                return NotFound();
            }

            return View(trabajadorModel);
        }

        // GET: Trabajador/Create
        public IActionResult Create()
        {
            _context.updateAll();
            ViewData["NacionalidadID"] = new SelectList(_context.Nacionalidades, "ID", "Pais");
            ViewData["EquipoID"] = new MultiSelectList(_context.Equipos, "ID", "Equipo");
            return View();
        }

        // POST: Trabajador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,NacionalidadID,Actor,Director,Especialista,Equipos")] TrabajadorModel trabajadorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadorModel);
                await _context.SaveChangesAsync();
                if (trabajadorModel.Actor && _context.Actores.FirstOrDefault(a => a.ActorID == trabajadorModel.ID) == null)
                {
                    ActorModel actorModel = new ActorModel();
                    actorModel.ActorID = trabajadorModel.ID;
                    _context.Add(actorModel);
                    await _context.SaveChangesAsync();
                }
                if (trabajadorModel.Especialista && _context.Especialistas.FirstOrDefault(e => e.EspecialistaID == trabajadorModel.ID) == null)
                {
                    foreach (int equipo in trabajadorModel.Equipos)
                    {
                        EspecialistaModel especialistaModel = new EspecialistaModel();
                        especialistaModel.EspecialistaID = trabajadorModel.ID;
                        especialistaModel.EquipoID = equipo;
                        _context.Add(especialistaModel);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NacionalidadID"] = new SelectList(_context.Nacionalidades, "ID", "Pais", trabajadorModel.NacionalidadID);
            ViewData["EquipoID"] = new MultiSelectList(_context.Equipos, "ID", "Equipo");
            return View(trabajadorModel);
        }

        // GET: Trabajador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadorModel = await _context.Trabajadores.FindAsync(id);
            if (trabajadorModel == null)
            {
                return NotFound();
            }

            ViewData["NacionalidadID"] = new SelectList(_context.Nacionalidades, "ID", "Pais", trabajadorModel.NacionalidadID);
            ViewData["EquipoID"] = new SelectList(_context.Equipos, "ID", "Equipo");
            return View(trabajadorModel);
        }

        // POST: Trabajador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,NacionalidadID,Actor,Director,Especialista,Equipos")] TrabajadorModel trabajadorModel)
        {
            if (id != trabajadorModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(trabajadorModel);
                    await _context.SaveChangesAsync();
                    if (trabajadorModel.Actor && (_context.Actores.FirstOrDefault(a => a.ActorID == trabajadorModel.ID) == null))
                    {
                        ActorModel actorModel = new ActorModel();
                        actorModel.ActorID = trabajadorModel.ID;
                        _context.Add(actorModel);
                        await _context.SaveChangesAsync();
                    }
                    else if (!trabajadorModel.Actor && (_context.Actores.FirstOrDefault(a => a.ActorID == trabajadorModel.ID) != null))
                    {
                        _context.Remove(_context.Actores.FirstOrDefault(a => a.ActorID == trabajadorModel.ID));
                    }

                    List<int> listaEquipos = new List<int>();
                    foreach (EspecialistaModel es in _context.Especialistas)
                    {
                        if (es.EspecialistaID == trabajadorModel.ID)
                        {
                            listaEquipos.Add(es.EquipoID);
                        }
                    }
                    trabajadorModel.Equipos = trabajadorModel.Equipos.IsNullOrEmpty() ? new List<int>() : trabajadorModel.Equipos;

                    List<int> relacionesAnadir = trabajadorModel.Equipos.Except(listaEquipos).ToList();
                    List<int> relacionesQuitar = listaEquipos.Except(trabajadorModel.Equipos).ToList();

                    foreach (int equipo in relacionesAnadir)
                    {
                        EspecialistaModel especialistaModel = new EspecialistaModel();
                        especialistaModel.EspecialistaID = trabajadorModel.ID;
                        especialistaModel.EquipoID = equipo;
                        _context.Add(especialistaModel);
                        await _context.SaveChangesAsync();
                    }
                    foreach (int equipo in relacionesQuitar)
                    {
                        foreach (EspecialistaModel es in _context.Especialistas)
                        {
                            if (es.EspecialistaID == trabajadorModel.ID && es.EquipoID == equipo)
                            {
                                _context.Remove(es);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadorModelExists(trabajadorModel.ID))
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
            ViewData["NacionalidadID"] = new SelectList(_context.Nacionalidades, "ID", "Pais", trabajadorModel.NacionalidadID);
            ViewData["EquipoID"] = new SelectList(_context.Equipos, "ID", "Equipo");
            return View(trabajadorModel);
        }

        // GET: Trabajador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _context.updateAll();
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadorModel = await _context.Trabajadores
                .Include(t => t.Nacionalidad)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trabajadorModel == null)
            {
                return NotFound();
            }

            return View(trabajadorModel);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trabajadores == null)
            {
                return Problem("Entity set 'Context.Trabajadores'  is null.");
            }
            var trabajadorModel = await _context.Trabajadores.FindAsync(id);
            if (trabajadorModel != null)
            {
                _context.Trabajadores.Remove(trabajadorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadorModelExists(int id)
        {
            return (_context.Trabajadores?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
