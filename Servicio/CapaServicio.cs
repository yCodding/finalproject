using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Servicio
{
    public class CapaServicio
    {
        static PFCapasEntities db = new PFCapasEntities();

        static public List<Entradas_Result> buscarEntrada(string nombre)
        {
            return db.Entradas(nombre).ToList();
        }

        static public List<Salidas_Result> buscarSalida(string nombre)
        {
            return db.Salidas(nombre).ToList();
        }

        static public List<Permiso_Result> buscarPermiso(string nombre)
        {
            return db.Permiso(nombre).ToList();
        }
    }
}
