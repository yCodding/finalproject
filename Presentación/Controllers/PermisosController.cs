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
    public class PermisosController : Controller
    {
        ModelEntities db = new ModelEntities();

        // GET: Permisos/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Permisos.Where(x => x.Empleado.Contains(nombre) || nombre == null).ToList());
        }

        //GET: Home/Permisos
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

        //POST: Home/Permisos
        [HttpPost]
        public ActionResult Create(Entidad.Permisos permisos)
        {
            try
            {
                CapaNegocio.agregarP(permisos);
                return RedirectToAction("Details", "Permisos");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar un permiso.");
                return View(permisos);
            }
        }

        // GET: Permisos/Edit/5
        public ActionResult Edit(int id)
        {
            var permiso = CapaNegocio.GetPermisos(id);
            return View(permiso);
        }

        // POST: Permisos/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Permisos permisos)
        {
            try
            {
                if (permisos.Empleado == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(permisos);
                }
                CapaNegocio.editarP(permisos);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar el permiso.");
                return View(permisos);
            }
        }

        // GET: Permisos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var permiso = CapaNegocio.GetPermisos(id.Value);
            return View(permiso);
        }

        // POST: Permisos/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarP(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar el permiso.");
                return View();
            }
        }
    }
}
