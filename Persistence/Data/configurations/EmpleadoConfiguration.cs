using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(p => p.NombreEmpleado)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.CargoEmpleado)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.FechaContratacion)
       .IsRequired();

    }
}

