using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentación.Models;

namespace Presentación.Controllers
{
    public class HomeController : Controller
    {
        ModelEntities db = new ModelEntities();   
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(string nombre)
        {
            return View(db.Empleados.Where(x => x.Nombre.Contains(nombre) || x.Estatus.StartsWith(nombre) || x.Departamentos.Nombre.StartsWith(nombre) || nombre == null).ToList());
        }

        //public ActionResult detallado()
        //{
        //    return View();
        //}

        // GET: Home/Create
        public ActionResult Create()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "--Seleccionar estado--", Selected=true});
            lst.Add(new SelectListItem() { Text = "Activo"});
            lst.Add(new SelectListItem() { Text = "Inactivo"});

            ViewBag.items = lst;
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Entidad.Empleados emplear)
        {
            try
            {
                CapaNegocio.agregarE(emplear);
                return RedirectToAction("Details", "Home");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al agregar empleado.");
                return View(emplear);
            }        
        }        

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var emplear = CapaNegocio.GetEmpleados(id);
            return View(emplear);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad.Empleados emp)
        {
            try
            {               
                CapaNegocio.editarE(emp);
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al editar el empleado.");
                return View(emp);
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var emp = CapaNegocio.GetEmpleados(id.Value);
            return View(emp);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                CapaNegocio.eliminarE(ID);
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
