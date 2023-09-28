

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
        .HasForeignKey(e => e.IdCiudadFk)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Direccion {Id=1,IdCiudadFk=1,TipoVia="via", Calle="70", Carrera="15", Numero="12", Complemento="sopas"},
            new Direccion {Id=2,IdCiudadFk=2,TipoVia="via", Calle="71", Carrera="15", Numero="12", Complemento="sopas"},
            new Direccion {Id=3,IdCiudadFk=3,TipoVia="via", Calle="72", Carrera="15", Numero="12", Complemento="sopas"}
        );
    }
}
 