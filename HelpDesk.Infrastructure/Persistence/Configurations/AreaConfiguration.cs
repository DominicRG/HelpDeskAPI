using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Persistence.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("area");

            builder.HasKey(x => x.IdArea);

            builder.Property(x => x.IdArea)
                .HasColumnName("id_area");

            builder.Property(x => x.Areaa)
                .HasColumnName("area")
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(x => x.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(x => x.UsuarioCreacionId)
                .HasColumnName("usuario_creacion_id")
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .IsRequired();

            builder.Property(x => x.UsuarioModificaId)
                .HasColumnName("usuario_modifica_id");

            builder.Property(x => x.FechaModifica)
                .HasColumnName("fecha_modifica");
        }
    }
}
