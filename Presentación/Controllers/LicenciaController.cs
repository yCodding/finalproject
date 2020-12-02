using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentación.Models;
using Presentación.Models.ViewModels;

namespace Presentación.Controllers
{
    public class LicenciaController : Controller
    {
        ModelEntities db = new ModelEntities();

        // GET: Licencia/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Licencias.Where(x => x.Empleado.Contains(nombre) || nombre == null).ToList());
        }

        //GET: Home/Licencia
        public ActionResult Create()
        {
            List<Tabla> lst = null;
            using (ModelEntities db = new ModelEntities())
            {
                lst = (from d in db.Empleados
                       select new Tabla
                       {
                           Nombre = d.Nombre
                       }).ToList();
            };

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            return View();
        }

        //POST: Home/Licencia
        [HttpPost]
        public ActionResult Create(Entidad.Licencias licencias)
        {
            try
            {
                CapaNegocio.agregarL(licencias);
                return RedirectToAction("Details", "Licencia");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar una nueva licencia.");
                return View(licencias);
            }
        }

        // GET: Licencia/Edit/5
        public ActionResult Edit(int id)
        {
            var lice = CapaNegocio.GetLicencias(id);
            return View(lice);
        }

        // POST: Licencia/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Licencias licencias)
        {
            try
            {
                if (licencias.Empleado == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(licencias);
                }
                CapaNegocio.editarL(licencias);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar la licencia.");
                return View(licencias);
            }
        }

        // GET: Licencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var lice = CapaNegocio.GetLicencias(id.Value);
            return View(lice);
        }

        // POST: Licencia/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarL(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar la licencia.");
                return View();
            }
        }
    }
}
