using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");
        builder.HasOne(p=>p.TipoPersona).WithMany(p=>p.Proveedores).HasForeignKey(p=>p.IdTipoPersonafk);
        builder.HasOne(p=>p.Municipio).WithMany(p=>p.Proveedores).HasForeignKey(p=>p.IdMunicipiofk);
        builder.
                HasMany(p=>p.Insumos)
        .WithMany(p=>p.Proveedores)
        .UsingEntity<InsumoProveedor>(
            j=>j.HasOne(p=>p.Insumo).WithMany(p=>p.InsumoProveedores).HasForeignKey(p=>p.IdInsumofk),
            j=>j.HasOne(p=>p.Proveedor).WithMany(p=>p.InsumoProveedores).HasForeignKey(p=>p.IdProveedorfk),
            j=>{
                j.HasKey(p=>new{p.IdProveedorfk, p.IdInsumofk});
            }
        );

    }
}
