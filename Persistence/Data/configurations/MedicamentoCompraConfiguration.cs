using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class MedicamentoCompraConfiguration : IEntityTypeConfiguration<MedicamentoCompra>
{
    public void Configure(EntityTypeBuilder<MedicamentoCompra> builder)
    {
        builder.ToTable("medicamento_compra");

        builder.Property(p => p.CantidadComprada)
        .IsRequired().HasColumnType("int");

        builder.Property(p => p.PrecioCompra)
       .IsRequired().HasColumnType("decimal(10,6)");

    }
}