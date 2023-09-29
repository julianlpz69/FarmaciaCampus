using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(p => p.NombreProveedor)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ContactoProveedor)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasOne(p => p.Direccion)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p => p.IdDireccionFK);

        builder.HasData(
                new Proveedor{Id=1, NombreProveedor = "Sesderma", NITProveedor = "12324", ContactoProveedor = "31231", IdDireccionFK = 1 },
                new Proveedor{Id=2, NombreProveedor = "Bayer", NITProveedor = "12324", ContactoProveedor = "31231", IdDireccionFK = 2},
                new Proveedor{Id=3, NombreProveedor = "Pfizer ", NITProveedor = "12324", ContactoProveedor = "31231", IdDireccionFK = 3}
            );
        
    }
}