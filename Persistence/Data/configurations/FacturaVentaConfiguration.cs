using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class FacturaVentaConfiguration : IEntityTypeConfiguration<FacturaVenta>
{
    public void Configure(EntityTypeBuilder<FacturaVenta> builder)
    {
        builder.ToTable("factura_venta");
        
        builder.Property(x => x.ValorTotal).HasColumnType("double").IsRequired();
        builder.Property(x => x.ValorTotal).HasColumnType("double").IsRequired();
   
        builder.HasOne(p => p.Empleado)
            .WithMany(p => p.FacturaVentas)
            .HasForeignKey(p => p.IdEmpleadoFK);

        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.FacturaVentas)
            .HasForeignKey(p => p.IdClienteFK);

        builder.HasOne(p => p.MetodoPago)
            .WithMany(p => p.FacturasVentas)
            .HasForeignKey(p => p.IdMetodoPagoFK);
        
     
    }
} 