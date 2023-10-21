using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {
        builder.ToTable("InsumoPrenda");
        builder.HasOne(p=>p.Insumo).WithMany(p=>p.InsumoPrendas).HasForeignKey(p=>p.IdInsumofk);
        builder.HasOne(p=>p.Prenda).WithMany(p=>p.InsumoPrendas).HasForeignKey(p=>p.IdPrendafk);

    }
}
