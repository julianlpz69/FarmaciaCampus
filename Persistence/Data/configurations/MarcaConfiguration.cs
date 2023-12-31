using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder){
    
            builder.ToTable("marca");
    
            builder.Property(e => e.NombreMarca)
                .HasMaxLength(30);

            builder.HasData(
                new Marca{Id=1, NombreMarca = "Sesderma"},
                new Marca{Id=2, NombreMarca = "Bayer"},
                new Marca{Id=3, NombreMarca = "Pfizer "}
            );
    
        }
    }
}