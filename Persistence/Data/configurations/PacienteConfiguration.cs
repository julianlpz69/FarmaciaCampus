using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("paciente");

        builder.Property(p => p.NombrePaciente)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.DireccionPaciente)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(p => p.TelefonoPaciente)
        .IsRequired()
        .HasMaxLength(15);
    }
}