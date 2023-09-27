

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new Pais { Id = 1, Nombre = "Argentina" },
            new Pais { Id = 2, Nombre = "Brasil" },
            new Pais { Id = 3, Nombre = "México" },
            new Pais { Id = 4, Nombre = "España" },
            new Pais { Id = 5, Nombre = "Estados Unidos" }
        );
    }
}
