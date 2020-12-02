using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentación.Models;

namespace Presentación.Controllers
{
    public class CargosController : Controller
    {
        ModelEntities db = new ModelEntities();

        //public ViewResult Index(string estado)
        //{

        //    var estados = db.Empleados.OrderBy(p => p.Departamentos.Nombre).Select(p => p.Nombre).Distinct();

        //    if (!String.IsNullOrEmpty(estado))
        //    {
        //        Entidad = db.Empleados.Where(s => s.Departamentos.Nombre.Contains(estado));
        //    }

        //    ViewBag.EstadosT = new SelectList(estados);
        //    return View(representante.ToList());
        //}

        // GET: Cargos/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Cargos.Where(x => x.Cargo.Contains(nombre) || nombre == null).ToList());
        }

        //GET: Home/Cargos
        public ActionResult Create()
        {
            return View();
        }

        //POST: Home/Cargos
        [HttpPost]
        public ActionResult Create(Entidad.Cargos cargos)
        {
            try
            {
                CapaNegocio.agregarC(cargos);
                return RedirectToAction("Details", "Cargos");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar un nuevo cargo.");
                return View(cargos);
            }
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int id)
        {
            var cargo = CapaNegocio.GetCargos(id);
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Cargos cargos)
        {
            try
            {
                if (cargos.Cargo == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(cargos);
                }
                CapaNegocio.editarC(cargos);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar el cargo.");
                return View(cargos);
            }
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var cargo = CapaNegocio.GetCargos(id.Value);
            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarC(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar el cargo.");
                return View();
            }
        }
    }
}
