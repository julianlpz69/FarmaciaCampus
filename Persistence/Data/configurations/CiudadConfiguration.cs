

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Departamento)
        .WithMany(e => e.Ciudades)
        .HasForeignKey(e => e.IdDepartamentoFk);

        builder.HasData(
            new Ciudad { Id = 1, Nombre = "Buenos Aires 1", IdDepartamentoFk = 1},
            new Ciudad { Id = 2, Nombre = "Buenos Aires 2", IdDepartamentoFk = 1 },
            new Ciudad { Id = 3, Nombre = "Córdoba 1", IdDepartamentoFk = 2 },
            new Ciudad { Id = 4, Nombre = "Córdoba 2", IdDepartamentoFk = 2},
            new Ciudad { Id = 5, Nombre = "Río de Janeiro 1", IdDepartamentoFk = 3 },
            new Ciudad { Id = 6, Nombre = "Río de Janeiro 2", IdDepartamentoFk = 3},
            new Ciudad { Id = 7, Nombre = "São Paulo 1", IdDepartamentoFk = 4 },
            new Ciudad { Id = 8, Nombre = "São Paulo 2", IdDepartamentoFk = 4 },
            new Ciudad { Id = 9, Nombre = "Estado de México 1", IdDepartamentoFk = 5 },
            new Ciudad { Id = 10, Nombre = "Estado de México 2", IdDepartamentoFk = 5 },
            new Ciudad { Id = 11, Nombre = "Jalisco 1", IdDepartamentoFk = 6 },
            new Ciudad { Id = 12, Nombre = "Jalisco 2", IdDepartamentoFk = 6 },
            new Ciudad { Id = 13, Nombre = "Madrid 1", IdDepartamentoFk = 7 },
            new Ciudad { Id = 14, Nombre = "Madrid 2", IdDepartamentoFk = 7 },
            new Ciudad { Id = 15, Nombre = "Barcelona 1", IdDepartamentoFk = 8 },
            new Ciudad { Id = 16, Nombre = "Barcelona 2", IdDepartamentoFk = 8 }, 
            new Ciudad { Id = 17, Nombre = "Nueva York 1", IdDepartamentoFk = 9 },
            new Ciudad { Id = 18, Nombre = "Nueva York 2", IdDepartamentoFk = 9 },
            new Ciudad { Id = 19, Nombre = "Chicago 1", IdDepartamentoFk = 10 },
            new Ciudad { Id = 20, Nombre = "Chicago 2", IdDepartamentoFk = 10 }
        );
    }
}
