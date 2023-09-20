using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder){
    
            builder.ToTable("cliente");
    
            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Cedula)
            .IsRequired()
            .HasMaxLength(50);

            
            builder.HasOne(p => p.Direccion)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdDireccionFk);
        }
    }
}