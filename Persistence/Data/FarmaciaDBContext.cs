using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class FarmaciaDBContext : DbContext
    {
        public FarmaciaDBContext(DbContextOptions<FarmaciaDBContext> options) : base(options)
        {
    
        }

        public DbSet<FacturaCompra> FacturaCompras { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoCompra> MedicamentosCompras { get; set; }
        public DbSet<MedicamentoVenta> MedicamentosVentas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<FacturaVenta> FacturaVentas { get; set; }
        public DbSet<MetodoPago> MetodoCoPagos {get; set;}
        public DbSet<Pais> Paises {get; set;}
        public DbSet<Departamento> Departamentos {get; set; }
        public DbSet<Ciudad> Ciudades {get; set;}
        public DbSet<Direccion> Direcciones {get; set;}
        public DbSet<Marca> Marcas {get; set;}
        public DbSet<CargoEmpleado> CargosEmpleados {get; set;}
        public DbSet<Receta> Recetas {get; set;}
        public DbSet<Empleado> Empleados {get; set;}        
        public DbSet<Cliente> Clientes {get; set;}    
        public DbSet<User> Users {get; set;}  
        public DbSet<Rol> Rols {get; set;}  
        public DbSet<UserRol> UserRols {get; set;}  
        public DbSet<TipoDocumento> TipoDocumentos {get; set;}  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}   