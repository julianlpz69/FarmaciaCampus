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

    }
}