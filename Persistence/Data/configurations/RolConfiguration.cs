using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

    public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {

        builder.ToTable("rol");
        builder.Property(p => p.Id)
                .IsRequired();
        builder.Property(p => p.NombreRol)
        .HasColumnName("rolName")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();


        builder.HasData(
            new Rol { Id = 1, NombreRol = "Empleado"},
            new Rol { Id = 2, NombreRol = "Administrador"}
        );
    }
}
   