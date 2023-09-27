
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");
        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Pais)
        .WithMany(e => e.Departamentos)
        .HasForeignKey(e => e.IdPaisFk);

        builder.HasData(
            new Departamento { Id = 1, Nombre = "Buenos Aires", IdPaisFk = 1},
            new Departamento { Id = 2, Nombre = "Córdoba", IdPaisFk = 1 },
            new Departamento { Id = 3, Nombre = "Río de Janeiro", IdPaisFk = 2 },
            new Departamento { Id = 4, Nombre = "São Paulo", IdPaisFk = 2},
            new Departamento { Id = 5, Nombre = "Departamento de México", IdPaisFk = 3 },
            new Departamento { Id = 6, Nombre = "Monterrey", IdPaisFk = 3},
            new Departamento { Id = 7, Nombre = "Madrid", IdPaisFk = 4 },
            new Departamento { Id = 8, Nombre = "Barcelona", IdPaisFk = 4 },
            new Departamento { Id = 9, Nombre = "Nueva York", IdPaisFk = 5 },
            new Departamento { Id = 10, Nombre = "Chicago", IdPaisFk = 5 }

        );
    }
}
