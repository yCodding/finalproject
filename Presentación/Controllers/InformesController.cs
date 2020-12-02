using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio;
using Presentación.Models;
using Presentación.Models.ViewModels;
namespace Presentación.Controllers
{
    public class InformesController : Controller
    {
        ModelEntities db = new ModelEntities();
        // GET: Informes/Entrada
        public ActionResult Entrada()
        {
            return View();
        }

        // POST: Informes/Entradas
        [HttpPost]
        public ActionResult Entradas(string nombre)
        {
            return View(CapaServicio.buscarEntrada(nombre));
        }

        // GET: Informes/Salida
        public ActionResult Salida()
        {
            return View();
        }

        // POST: Informes/Salidas
        [HttpPost]
        public ActionResult Salidas(string nombre)
        {
            return View(CapaServicio.buscarSalida(nombre));
        }

        // GET: Informes/Activos
        public ActionResult Activos(string nombre)
        {
            nombre = "Activo";
            return View(db.Empleados.Where(x => x.Estatus.StartsWith(nombre) || x.Nombre.Contains(nombre) || x.Departamentos.Nombre.Contains(nombre) || nombre == null).ToList());
        }

        // GET: Informes/Inactivos
        public ActionResult Inactivos(string nombre)
        {
            nombre = "Inactivo";
            return View(db.Empleados.Where(x => x.Estatus.StartsWith(nombre) || nombre == null).ToList());
        }

        // GET: Informes/Permiso
        public ActionResult Permiso()
        {
            List<Tabla> lst = null;
            using (ModelEntities db = new ModelEntities())
            {
                lst = (from d in db.Permisos
                       select new Tabla
                       {
                           Nombre = d.Empleado
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

        // GET: Informes/Permisos/5
        public ActionResult Permisos(string nombre)
        {            
            return View(CapaServicio.buscarPermiso(nombre));
        }

    }
}
