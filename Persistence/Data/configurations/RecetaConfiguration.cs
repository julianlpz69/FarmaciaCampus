using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class RecetaConfiguration : IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder){
    
            builder.ToTable("receta");
    
            builder.Property(e => e.Remitente)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descripcion)
            .HasMaxLength(200)
            .IsRequired();

            builder.HasOne(p => p.FacturaVenta)
            .WithMany(p => p.Recetas)
            .HasForeignKey(p => p.IdFacturaVentaFK);
        }
    }
}  