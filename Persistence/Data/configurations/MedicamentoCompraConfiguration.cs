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

       builder.HasOne(p => p.Compra)
       .WithMany(p => p.MedicamentosCompras)
       .HasForeignKey(p => p.IdCompraFK);

       builder.HasOne(p => p.Medicamento)
       .WithMany(p => p.MedicamentosCompras)
       .HasForeignKey(p => p.IdMedicamentoFK);
    }
}