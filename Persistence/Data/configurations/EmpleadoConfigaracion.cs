using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder){
    
            builder.ToTable("Empleado");
    
             builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Cedula)
            .IsRequired()
            .HasMaxLength(50);

            
            builder.HasOne(p => p.Direccion)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdDireccionFk);

            builder.HasOne(p => p.CargoEmpleado)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdCargoEmpleadoFK);

            
    
        }
    }
}