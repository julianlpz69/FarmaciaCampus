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

        public DbSet<Compra> Compras { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoCompra> MedicamentosCompras { get; set; }
        public DbSet<MedicamentoVenta> MedicamentosVentas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}