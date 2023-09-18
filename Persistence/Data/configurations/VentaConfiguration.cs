using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder.Property(v => v.FechaVenta)
        .IsRequired();


        builder.HasOne(p => p.Paciente)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdPacienteFK);


        builder.HasOne(p => p.Empleado)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdEmpleadoFK);
        
        builder.HasMany(e => e.Medicamentos)
        .WithMany(e => e.Ventas)
        .UsingEntity<MedicamentoVenta>(
            e => e.HasOne(p => p.Medicamento)
            .WithMany(e => e.MedicamentoVentas)
            .HasForeignKey(e => e.IdMedicamentoFK),

            e => e.HasOne(f => f.Venta)
            .WithMany(f => f.MedicamentoVentas)
            .HasForeignKey(e => e.IdVentaFK),
            e => {
                e.HasKey( f => new {f.IdVentaFK, f.IdMedicamentoFK});
            }
        );
    }
} 