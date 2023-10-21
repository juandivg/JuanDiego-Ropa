using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("Orden");
        builder.HasOne(p=>p.Empleado).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.IdEmpleadofk);
        builder.HasOne(p=>p.Cliente).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.IdClientefk);
        builder.HasOne(p=>p.Estado).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.IdEstadofk);
    }
}
