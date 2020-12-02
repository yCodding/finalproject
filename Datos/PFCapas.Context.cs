﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using Entidad;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PFCapasEntities : DbContext
    {
        public PFCapasEntities()
            : base("name=PFCapasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Licencias> Licencias { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Salida> Salida { get; set; }
        public virtual DbSet<Vacaciones> Vacaciones { get; set; }
        public virtual DbSet<CNomina> CNomina { get; set; }
    
        public virtual ObjectResult<Entradas_Result> Entradas(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Entradas_Result>("Entradas", nombreParameter);
        }
    
        public virtual ObjectResult<Salidas_Result> Salidas(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Salidas_Result>("Salidas", nombreParameter);
        }
    
        public virtual ObjectResult<Permiso_Result> Permiso(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Permiso_Result>("Permiso", nombreParameter);
        }
    }
}
