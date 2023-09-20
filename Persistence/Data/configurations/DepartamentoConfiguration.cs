
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");
        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Pais)
        .WithMany(e => e.Departamentos)
        .HasForeignKey(e => e.IdPaisFk);
    }
}
