using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class VentaConfiguration : IEntityTypeConfiguration<FacturaVenta>
{
    public void Configure(EntityTypeBuilder<FacturaVenta> builder)
    {
        builder.ToTable("factura_venta");
        
        builder.Property(e => e.IdFacturaBaseFk)
        .IsRequired();

        builder.HasOne(p => p.Paciente)
        .WithMany(p => p.FacturaVentas)
        .HasForeignKey(p => p.IdFacturaBaseFk);
        
        builder.HasOne(e => e.FacturaBase)
        .WithMany(e => e.FacturaVentas)
        .HasForeignKey(e => e.IdFacturaBaseFk);
    }
} 