using Formularios_BBDD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Formularios_BBDD.Controllers
{
    public class NacionalidadControlador : Controller
    {
        public Contexto Contexto { get; set; }
        public NacionalidadControlador(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: Nacionalidad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nacionalidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nacionalidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NacionalidadModelo nacionalidad)
        {
            try
            {
                Contexto.Nacionalidades.Add(nacionalidad);
                Contexto.Database.EnsureCreated();
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Nacionalidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nacionalidad/Edit/5
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

        // GET: Nacionalidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nacionalidad/Delete/5
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
