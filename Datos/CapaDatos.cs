using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class CapaDatos
    {
        //----------------------------Empleados----------------------------

        public Empleados GetEmpleados(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Empleados.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirEmpleado(Empleados emp)
        {
            using (var db = new PFCapasEntities())
            {
                db.Empleados.Add(emp);
                db.SaveChanges();
            }
        }

        public void editarEmpleado(Empleados emp)
        {
            using (var db = new PFCapasEntities())
            {
                var emplear = db.Empleados.Find(emp.ID);
                emplear.Codigo = emp.Codigo;  
                emplear.Nombre = emp.Nombre;  
                emplear.Apellido = emp.Apellido;  
                emplear.Telefono = emp.Telefono;  
                emplear.fechaIngreso = emp.fechaIngreso;  
                emplear.Salario = emp.Salario;  
                emplear.Estatus = emp.Estatus;
                emplear.Departamento = emp.Departamento;
                emplear.Cargo = emp.Cargo;

                db.SaveChanges();
            }
        }

        public void eliminarEmpleado(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var emp = db.Empleados.Find(ID);
                db.Empleados.Remove(emp);

                db.SaveChanges();
            }
        }

        public List<Empleados> ListarEmpleados()
        {
            using (var db = new PFCapasEntities())
                    {
                return db.Empleados.ToList();
            }
        }
        //----------------------------Departamentos----------------------------

        public Departamentos GetDepartamentos(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Departamentos.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirDepartamentos(Departamentos dp)
        {
            using (var db = new PFCapasEntities())
            {
                db.Departamentos.Add(dp);
                db.SaveChanges();
            }
        }

        public void editarDept(Departamentos dpt)
        {
            using (var db = new PFCapasEntities())
            {
                var dept = db.Departamentos.Find(dpt.ID);
                dept.Codigo = dpt.Codigo;
                dept.Nombre = dpt.Nombre;

                db.SaveChanges();
            }
        }

        public void eliminarDept(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var dept = db.Departamentos.Find(ID);
                db.Departamentos.Remove(dept);

                db.SaveChanges();
            }
        }

        public List<Departamentos> listarDepartamentos()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Departamentos.ToList();
            }
        }
        //----------------------------Cargos----------------------------

        public Cargos GetCargos(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Cargos.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirCargos(Cargos cargos)
        {
            using (var db = new PFCapasEntities())
            {
                db.Cargos.Add(cargos);
                db.SaveChanges();
            }
        }

        public void editarCargo(Cargos cargos)
        {
            using (var db = new PFCapasEntities())
            {
                var car = db.Cargos.Find(cargos.ID);
                car.Cargo = cargos.Cargo;

                db.SaveChanges();
            }
        }

        public void eliminarCargos(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var cargo = db.Cargos.Find(ID);
                db.Cargos.Remove(cargo);

                db.SaveChanges();
            }
        }

        public List<Cargos> listarCargos()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Cargos.ToList();
            }
        }

        //----------------------------Salida de Empleados----------------------------

        public Salida GetSalida(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Salida.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirSalida(Salida salida)
        {
            using (var db = new PFCapasEntities())
            {
                db.Salida.Add(salida);
                db.SaveChanges();
            }
        }

        public void editarSalida(Salida salida)
        {
            using (var db = new PFCapasEntities())
            {
                var sal = db.Salida.Find(salida.ID);
                sal.Empleado = salida.Empleado;
                sal.tipoSalida = salida.tipoSalida;
                sal.Motivo = salida.Motivo;
                sal.fechaSalida = salida.fechaSalida;

                db.SaveChanges();
            }
        }

        public void eliminarSalida(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var sal = db.Salida.Find(ID);
                db.Salida.Remove(sal);

                db.SaveChanges();
            }
        }

        public List<Salida> listarSalida()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Salida.ToList();
            }
        }

        //----------------------------Licencias----------------------------

        public Licencias GetLicencias(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Licencias.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirLicencias(Licencias licencias)
        {
            using (var db = new PFCapasEntities())
            {
                db.Licencias.Add(licencias);
                db.SaveChanges();
            }
        }

        public void editarLicencias(Licencias licencias)
        {
            using (var db = new PFCapasEntities())
            {
                var linc = db.Licencias.Find(licencias.ID);
                linc.Empleado = licencias.Empleado;
                linc.Desde = licencias.Desde;
                linc.Hasta = licencias.Hasta;
                linc.Motivo = licencias.Motivo;
                linc.Comentarios = licencias.Comentarios;

                db.SaveChanges();
            }
        }

        public void eliminarLicencias(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var linc = db.Licencias.Find(ID);
                db.Licencias.Remove(linc);

                db.SaveChanges();
            }
        }

        public List<Licencias> listarLicencias()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Licencias.ToList();
            }
        }
        //-----------------------------Vacaciones----------------------------

        public Vacaciones GetVacaciones(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Vacaciones.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirVacaciones(Vacaciones vacaciones)
        {
            using (var db = new PFCapasEntities())
            {
                db.Vacaciones.Add(vacaciones);
                db.SaveChanges();
            }
        }

        public void editarVacaciones(Vacaciones vacaciones)
        {
            using (var db = new PFCapasEntities())
            {
                var vac = db.Permisos.Find(vacaciones.ID);
                vac.Empleado = vacaciones.Empleado;
                vac.Desde = vacaciones.Desde;
                vac.Hasta = vacaciones.Hasta;
                vac.Comentarios = vacaciones.Comentarios;

                db.SaveChanges();
            }
        }

        public void eliminarVacaciones(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var vac = db.Vacaciones.Find(ID);
                db.Vacaciones.Remove(vac);

                db.SaveChanges();
            }
        }

        public List<Vacaciones> listarVacaciones()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Vacaciones.ToList();
            }
        }

        //----------------------------Permisos----------------------------

        public Permisos GetPermisos(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.Permisos.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirPermisos(Permisos permisos)
        {
            using (var db = new PFCapasEntities())
            {
                db.Permisos.Add(permisos);
                db.SaveChanges();
            }
        }

        public void editarPermisos(Permisos permisos)
        {
            using (var db = new PFCapasEntities())
            {
                var per = db.Permisos.Find(permisos.ID);
                per.Empleado = permisos.Empleado;
                per.Desde = permisos.Desde;
                per.Hasta = permisos.Hasta;
                per.Comentarios = permisos.Comentarios;

                db.SaveChanges();
            }
        }

        public void eliminarPermisos(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var per = db.Permisos.Find(ID);
                db.Permisos.Remove(per);

                db.SaveChanges();
            }
        }

        public List<Permisos> listarPermisos()
        {
            using (var db = new PFCapasEntities())
            {
                return db.Permisos.ToList();
            }
        }

        //----------------------------Nóminas de Empleados----------------------------
        public CNomina GetNomina(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                return db.CNomina.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public void añadirNomina(CNomina nomina)
        {
            using (var db = new PFCapasEntities())
            {
                db.CNomina.Add(nomina);
                db.SaveChanges();
            }
        }

        public void editarNomina(CNomina nomina)
        {
            using (var db = new PFCapasEntities())
            {
                var nom = db.CNomina.Find(nomina.ID);
                nom.Año = nomina.Año;
                nom.Mes = nomina.Mes;
                nom.montoTotal = nomina.montoTotal;

                db.SaveChanges();
            }
        }

        public void eliminarNomina(int ID)
        {
            using (var db = new PFCapasEntities())
            {
                var nom = db.CNomina.Find(ID);
                db.CNomina.Remove(nom);

                db.SaveChanges();
            }
        }

        public List<CNomina> listarNomina()
        {
            using (var db = new PFCapasEntities())
            {
                return db.CNomina.ToList();
            }
        }
    }
}
