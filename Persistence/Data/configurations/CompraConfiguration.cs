using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {   
        builder.ToTable("compra");

        builder.Property(c => c.FechaCompra)
        .IsRequired();

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.Compras)
        .HasForeignKey(p => p.IdProveedorFK);

        builder.HasMany(e => e.Medicamentos)
        .WithMany(e => e.Compras)
        .UsingEntity<MedicamentoCompra>(
            e => e.HasOne(p => p.Medicamento)
            .WithMany(p => p.MedicamentosCompras)
            .HasForeignKey(p => p.IdMedicamentoFK),
            
            e => e.HasOne(p => p.Compra)
            .WithMany(p => p.MedicamentosCompras)
            .HasForeignKey(e => e.IdCompraFK),
            p => {
                p.ToTable("medicamento_compra");
                p.HasKey( e => new {e.IdMedicamentoFK, e.IdCompraFK});
            }
        );
    }
}