using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentación.Models;

namespace Presentación.Controllers
{
    public class DepartmentController : Controller
    {
        ModelEntities db = new ModelEntities();
        // GET: Department/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Departamentos.Where(x => x.Nombre.Contains(nombre) || nombre == null).ToList());
        }

        //GET: Home/Departamento
        public ActionResult Create()
        {
            return View();
        }

        //POST: Home/Departamento
        [HttpPost]
        public ActionResult Create(Entidad.Departamentos dep)
        {
            try
            {
                CapaNegocio.agregarD(dep);
                return RedirectToAction("Details", "Department");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar un nuevo departamento.");
                return View(dep);
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var dpt = CapaNegocio.GetDepartamentos(id);
            return View(dpt);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Departamentos dept)
        {
            try
            {
                if (dept.Nombre == null)
                {
                    ModelState.AddModelError("", "Debe rellenar este campo.");
                    return View(dept);
                }
                CapaNegocio.editarD(dept);
                return RedirectToAction("Details");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar el departamento.");
                return View(dept);
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var dpt = CapaNegocio.GetDepartamentos(id.Value);
            return View(dpt);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarD(ID);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar el departamento.");
                return View();
            }
        }
    }
}
