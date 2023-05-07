using Formularios_BBDD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Formularios_BBDD.Controllers
{
    public class TrabajadorController : Controller
    {
        public Context Contexto { get; set; }
        public TrabajadorController(Context contexto)
        {
            Contexto = contexto;
        }
        // GET: TrabajadorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrabajadorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrabajadorController/Create
        public ActionResult Create()
        {
            ViewBag.Paises = new SelectList(Contexto.Nacionalidades, "ID", "Pais");
            return View();
        }

        // POST: TrabajadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrabajadorModel trabajador)
        {
            try
            {
                Contexto.Trabajadores.Add(trabajador);
                Contexto.Database.EnsureCreated();
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: TrabajadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrabajadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrabajadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrabajadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
