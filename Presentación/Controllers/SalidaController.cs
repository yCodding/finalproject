using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentación.Models;
using Presentación.Models.ViewModels;
using Negocio;

namespace Presentación.Controllers
{
    public class SalidaController : Controller
    {
        //public ActionResult Index()
        //{
        //    List<SelectListItem> lst = new List<SelectListItem>();
        //    using (ModelEntities db = new ModelEntities())
        //    {
        //        lst = (from d in db.Empleados
        //             select new SelectListItem
        //             {
        //                 Value = d.ID.ToString(),
        //                 Text = d.Nombre
        //             }).ToList();
        //    };
           
        //    return View(lst);
        //}

        ModelEntities db = new ModelEntities();
        // GET: Salida/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Salida.Where(x => x.Empleado.Contains(nombre) || nombre == null).ToList());
        }

        // GET: Salida/Create
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

        // POST: Salida/Create
        [HttpPost]
        public ActionResult Create(Entidad.Salida sal)
        {
            try
            {
                CapaNegocio.agregarS(sal);
                return RedirectToAction("Details", "Salida");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar una salida.");
                return View(sal);
            }
        }

        // GET: Salida/Edit/5
        public ActionResult Edit(int id)
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

            var sal = CapaNegocio.GetSalida(id);
            return View(sal);
        }

        // POST: Salida/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Salida salida)
        {
            try
            {
                if (salida.Empleado == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(salida);
                }
                CapaNegocio.editarS(salida);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar.");
                return View(salida);
            }
        }

        // GET: Salida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var sal = CapaNegocio.GetSalida(id.Value);
            return View(sal);
        }

        // POST: Salida/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarS(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar la salida.");
                return View();
            }
        }
    }
}
