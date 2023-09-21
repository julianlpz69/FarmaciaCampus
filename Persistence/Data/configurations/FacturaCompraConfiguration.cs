using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class FacturaCompraConfiguration : IEntityTypeConfiguration<FacturaCompra>
{
    public void Configure(EntityTypeBuilder<FacturaCompra> builder)
    {   
        builder.ToTable("factura_compra");

        builder.Property(f => f.ValorTotal).IsRequired().HasColumnType("double");
        

        builder.HasOne(e => e.Proveedor)
        .WithMany(e => e.FacturaCompras)
        .HasForeignKey(e => e.IdProveedorFk);

        builder.HasOne(p => p.MetodoPago)
            .WithMany(p => p.FacturasCompras)
            .HasForeignKey(p => p.IdMetodoPagoFK);




    }
} 