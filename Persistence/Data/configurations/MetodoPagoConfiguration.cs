

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class MetodoCompraConfiguration : IEntityTypeConfiguration<MetodoCompra>
{
    public void Configure(EntityTypeBuilder<MetodoCompra> builder)
    {
        builder.ToTable("metodo_pago");

        builder.Property(e => e.Descripcion)
        .IsRequired()
        .HasMaxLength(50);
    }
}
