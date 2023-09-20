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
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoCompra> MedicamentosCompras { get; set; }
        public DbSet<MedicamentoVenta> MedicamentosVentas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<FacturaVenta> FacturaVentas { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}