using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class MedicamentoVentaConfiguration : IEntityTypeConfiguration<MedicamentoVenta>
{
    public void Configure(EntityTypeBuilder<MedicamentoVenta> builder)
    {
        builder.ToTable("medicamento_venta");
        
        builder.Property(p => p.CantidadVendida)
        .IsRequired().HasColumnType("int");

        builder.Property(p => p.Precio)
        .IsRequired().HasColumnType("decimal(10,6)");
    }
}