using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infrastructure.Persistence.Configurations
{
    public  class PersonConfiguration: IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Nombres).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Apellidos).IsRequired();

            builder.Property(p => p.FechaCreacion).HasDefaultValueSql("NOW()");

            builder.Property(p => p.FechaActualizacion).HasDefaultValueSql("NOW()");

            builder.Property(p => p.SyncStatus).HasDefaultValue(Domain.Enums.SyncStatus.Pending);


        }

    }
}
