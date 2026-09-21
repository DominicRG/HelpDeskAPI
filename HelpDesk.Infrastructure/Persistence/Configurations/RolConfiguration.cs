using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Persistence.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("rol");

            builder.HasKey(x => x.IdRol);

            builder.Property(x => x.IdRol)
                .HasColumnName("id_rol")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion");

            builder.Property(x => x.Activo)
                .HasColumnName("activo")
                .IsRequired();
        }
    }
}
