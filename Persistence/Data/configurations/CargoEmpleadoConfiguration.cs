
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class CargoEmpleadoConfiguration : IEntityTypeConfiguration<CargoEmpleado>
{
    public void Configure(EntityTypeBuilder<CargoEmpleado> builder)
    {
        builder.ToTable("cargoEmpleado");

        builder.Property(e => e.NombreCargo)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new CargoEmpleado { Id = 1, NombreCargo = "Gerente"},
            new CargoEmpleado { Id = 2, NombreCargo = "Enfermero"},
            new CargoEmpleado { Id = 3, NombreCargo = "Cajero"},
            new CargoEmpleado { Id = 4, NombreCargo = "Auxiliar"}
        );
    }
}
