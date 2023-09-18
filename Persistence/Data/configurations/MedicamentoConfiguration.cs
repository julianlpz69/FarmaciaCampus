using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");

        builder.Property(p => p.NombreMedicamento)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.PrecioMedicamento)
        .IsRequired().HasColumnType("decimal(10,6)");

        builder.Property(p => p.Stock)
        .IsRequired().HasColumnType("int");

        builder.Property(p => p.FechaExpiracion)
        .IsRequired();

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.IdProveedorFK);


    }
}