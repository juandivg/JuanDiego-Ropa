using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {
       builder.ToTable("InventarioTalla");
       builder.HasOne(p=>p.Inventario).WithMany(p=>p.InventarioTallas).HasForeignKey(p=>p.IdInventariofk);
       builder.HasOne(p=>p.Talla).WithMany(p=>p.InventarioTallas).HasForeignKey(p=>p.IdTallafk);
    }
}
