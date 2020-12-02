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
    public class VacacionesController : Controller
    {
        ModelEntities db = new ModelEntities();

        // GET: Vacaciones/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Vacaciones.Where(x => x.Empleado.Contains(nombre) || nombre == null).ToList());
        }

        //GET: Home/Vacaciones
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

        //POST: Home/Vacaciones
        [HttpPost]
        public ActionResult Create(Entidad.Vacaciones vacaciones)
        {
            try
            {
                CapaNegocio.agregarV(vacaciones);
                return RedirectToAction("Details", "Vacaciones");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar tiempo de vacación.");
                return View(vacaciones);
            }
        }

        // GET: Vacaciones/Edit/5
        public ActionResult Edit(int id)
        {
            var vac = CapaNegocio.GetVacaciones(id);
            return View(vac);
        }

        // POST: Vacaciones/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Vacaciones vacaciones)
        {
            try
            {
                if (vacaciones.Empleado == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(vacaciones);
                }
                CapaNegocio.editarV(vacaciones);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar la vacación.");
                return View(vacaciones);
            }
        }

        // GET: Vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var vac = CapaNegocio.GetVacaciones(id.Value);
            return View(vac);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarV(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar vacaciones.");
                return View();
            }
        }
    }
}
