using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
               builder
        .HasMany(p => p.Roles)
        .WithMany(p => p.Usuarios)
        .UsingEntity<UsuarioRol>(
            j => j
            .HasOne(p => p.Rol)
            .WithMany(p => p.UsuarioRoles)
            .HasForeignKey(p => p.IdRolfk),

            j => j
            .HasOne(p => p.Usuario)
            .WithMany(p => p.UsuarioRoles)
            .HasForeignKey(p => p.IdUsuariofk),

            j =>
            {
                j.ToTable("usuarioRol");
                j.HasKey(p => new { p.IdUsuariofk, p.IdRolfk });
            });
        builder.HasMany(p => p.RefreshTokens)
        .WithOne(p => p.Usuario)
        .HasForeignKey(p => p.IdUsuariofk);
}
}