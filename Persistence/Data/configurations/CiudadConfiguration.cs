

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Departamento)
        .WithMany(e => e.Ciudades)
        .HasForeignKey(e => e.IdDepartamentoFk);
    }
}
