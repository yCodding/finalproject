using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class CapaNegocio
    {

        //----------------------------Empleados----------------------------

        public static Empleados GetEmpleados(int ID)
        {
            return cd.GetEmpleados(ID);
        }

        private static CapaDatos cd = new CapaDatos();
        public static List<Empleados> listarEmpleado()
        {
            return cd.ListarEmpleados();
        }

        public static void agregarE(Empleados emp)
        {
            cd.añadirEmpleado(emp);
        }

        public static void editarE(Empleados emp)
        {
            cd.editarEmpleado(emp);
        }

        public static void eliminarE(int ID)
        {
            cd.eliminarEmpleado(ID);
        }
        //----------------------------Departamentos----------------------------

        public static Departamentos GetDepartamentos(int ID)
        {
            return cd.GetDepartamentos(ID);
        }

        public static List<Departamentos> listarDepartamento()
        {
            return cd.listarDepartamentos();
        }
        public static void agregarD(Departamentos dp)
        {
            cd.añadirDepartamentos(dp);
        }

        public static void editarD(Departamentos dept)
        {
            cd.editarDept(dept);
        }

        public static void eliminarD(int ID)
        {
            cd.eliminarDept(ID);
        }
        //----------------------------Cargos----------------------------

        public static Cargos GetCargos(int ID)
        {
            return cd.GetCargos(ID);
        }
        public static List<Cargos> listarCargo()
        {
            return cd.listarCargos();
        }
        public static void agregarC(Cargos cargo)
        {
            cd.añadirCargos(cargo);
        }
        
        public static void editarC(Cargos cargos)
        {
            cd.editarCargo(cargos);
        }

        public static void eliminarC(int ID)
        {
            cd.eliminarCargos(ID);
        }

        //----------------------------Salida de Empleados----------------------------

        public static Salida GetSalida(int ID)
        {
            return cd.GetSalida(ID);
        }
        public static List<Salida> listarSalida()
        {
            return cd.listarSalida();
        }
        public static void agregarS(Salida salida)
        {
            cd.añadirSalida(salida);
        }

        public static void editarS(Salida salida)
        {
            cd.editarSalida(salida);
        }

        public static void eliminarS(int ID)
        {
            cd.eliminarSalida(ID);
        }

        //----------------------------Licencias----------------------------

        public static Licencias GetLicencias(int ID)
        {
            return cd.GetLicencias(ID);
        }

        public static List<Licencias> listarLicencias()
        {
            return cd.listarLicencias();
        }
        public static void agregarL(Licencias licencias)
        {
            cd.añadirLicencias(licencias);
        }

        public static void editarL(Licencias licencias)
        {
            cd.editarLicencias(licencias);
        }

        public static void eliminarL(int ID)
        {
            cd.eliminarLicencias(ID);
        }
        //----------------------------Vacaciones----------------------------

        public static Vacaciones GetVacaciones(int ID)
        {
            return cd.GetVacaciones(ID);
        }
        public static List<Vacaciones> listarVacaciones()
        {
            return cd.listarVacaciones();
        }
        public static void agregarV(Vacaciones vacaciones)
        {
            cd.añadirVacaciones(vacaciones);
        }

        public static void editarV(Vacaciones vacaciones)
        {
            cd.editarVacaciones(vacaciones);
        }

        public static void eliminarV(int ID)
        {
            cd.eliminarVacaciones(ID);
        }

        //----------------------------Permisos----------------------------

        public static Permisos GetPermisos(int ID)
        {
            return cd.GetPermisos(ID);
        }
        public static List<Permisos> listarPermisos()
        {
            return cd.listarPermisos();
        }
        public static void agregarP(Permisos permisos)
        {
            cd.añadirPermisos(permisos);
        }

        public static void editarP(Permisos permisos)
        {
            cd.editarPermisos(permisos);
        }

        public static void eliminarP(int ID)
        {
            cd.eliminarPermisos(ID);
        }

        //----------------------------Nóminas de Empleados----------------------------

        public static CNomina GetNomina(int ID)
        {
            return cd.GetNomina(ID);
        }
        public static List<CNomina> listarNomina()
        {
            return cd.listarNomina();
        }
        public static void agregarN(CNomina nomina)
        {
            cd.añadirNomina(nomina);
        }

        public static void editarN(CNomina nomina)
        {
            cd.editarNomina(nomina);
        }

        public static void eliminarN(int ID)
        {
            cd.eliminarNomina(ID);
        }
    }
}
