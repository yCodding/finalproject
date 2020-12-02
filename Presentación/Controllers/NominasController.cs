using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentación.Models;

namespace Presentación.Controllers
{
    public class NominasController : Controller
    {
        ModelEntities db = new ModelEntities();

        // GET: Nominas/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.CNomina.Where(x => x.Año.Contains(nombre) || x.Mes.Contains(nombre) || nombre == null).ToList());
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        [HttpPost]
        public ActionResult Create(Entidad.CNomina nomina)
        {
            try
            {
                CapaNegocio.agregarN(nomina);
                return RedirectToAction("Details", "Nominas");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar nómina.");
                return View(nomina);
            }
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int id)
        {
            var nomina = CapaNegocio.GetNomina(id);
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.CNomina nomina)
        {
            try
            {
                CapaNegocio.editarN(nomina);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar la nómina.");
                return View(nomina);
            }
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var nomina = CapaNegocio.GetNomina(id.Value);
            return View(nomina);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarN(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar la nómina.");
                return View();
            }
        }
    }
}
