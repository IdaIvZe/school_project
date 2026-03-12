using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {


        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.IdRol);

            builder.Property(r => r.NombreRol).IsRequired();

            builder.Property(r => r.DescripcionRol);

            builder.Property(r => r.CodigoRol);

        }
    }
}
