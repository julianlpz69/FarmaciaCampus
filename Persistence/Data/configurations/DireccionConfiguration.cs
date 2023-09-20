

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");

        builder.Property(e => e.Numero)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Calle)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Ciudad)
        .WithMany(e => e.Direcciones)
        .HasForeignKey(e => e.IdCiudadFk);

        
    }
}
