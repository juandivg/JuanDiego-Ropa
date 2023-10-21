using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
    public void Configure(EntityTypeBuilder<FormaPago> builder)
    {
        builder.ToTable("FormaPago");
    }
}
