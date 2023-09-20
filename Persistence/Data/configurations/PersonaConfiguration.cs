using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Cedula)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(e => e.Cedula).IsUnique();

        builder.HasOne(e => e.Direccion)
        .WithMany(e => e.Personas)
        .HasForeignKey(e => e.IdDireccionFk);

        builder.HasOne(e => e.TipoPersona)
        .WithMany(e => e.Personas)
        .HasForeignKey(e => e.IdTipoPersonaFk);

        builder.HasOne(e => e.Cargo)
        .WithMany(e => e.Personas)
        .HasForeignKey(e => e.IdCargoFk);

    }
}
