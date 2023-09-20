using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

    public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        {
            builder.ToTable("user");

            builder.Property(p => p.UserName)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.UserPassword)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.UserEmail)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder
           .HasMany(p => p.Rols)
           .WithMany(r => r.Users)
           .UsingEntity<UserRol>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.UsersRols)
               .HasForeignKey(ut => ut.IdRol),


               j => j
               .HasOne(et => et.User)
               .WithMany(et => et.UsersRols)
               .HasForeignKey(el => el.IdUser),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdUser, t.IdRol });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        }

    }
}
