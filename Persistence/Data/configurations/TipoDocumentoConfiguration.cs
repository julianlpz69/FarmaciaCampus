using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder){
    
            builder.ToTable("tipo_documento");

            builder.Property(e => e.NombreTipoDocumento)
                .HasMaxLength(30);


            builder.HasData(
                new TipoDocumento { Id = 1, NombreTipoDocumento = "Cedula Ciudadania"},
                new TipoDocumento { Id = 2, NombreTipoDocumento = "Tarjeta Identidad"},
                new TipoDocumento { Id = 3, NombreTipoDocumento = "Pasaporte"},
                new TipoDocumento { Id = 4, NombreTipoDocumento = "Cedula Extranjeria"},
                new TipoDocumento { Id = 5, NombreTipoDocumento = "PPT"}
        );
    
        }
    }
}