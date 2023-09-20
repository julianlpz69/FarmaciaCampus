
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;
public class FacturaBaseConfiguration : IEntityTypeConfiguration<FacturaBase>
{
    public void Configure(EntityTypeBuilder<FacturaBase> builder)
    {
        builder.ToTable("factura_base");

        builder.Property(e => e.CodigoCompra)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(e => e.CodigoCompra).IsUnique();
        
        builder.Property(e => e.TotalIva)
        .IsRequired();

        builder.Property(e => e.Total)
        .IsRequired();

    }
}
