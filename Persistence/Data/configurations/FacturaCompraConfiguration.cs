using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CompraConfiguration : IEntityTypeConfiguration<FacturaCompra>
{
    public void Configure(EntityTypeBuilder<FacturaCompra> builder)
    {   
        builder.ToTable("factura_compra");

        builder.Property(c => c.IdFacturaBaseFk)
        .IsRequired();

        builder.HasOne(p => p.FacturaBase)
        .WithMany(p => p.FacturaCompras)
        .HasForeignKey(p => p.IdFacturaBaseFk);

        builder.HasOne(e => e.Proveedor)
        .WithMany(e => e.FacturaCompras)
        .HasForeignKey(e => e.IdProveedorFk);

    }
}