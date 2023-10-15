using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
        {
            public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
            {
                builder.ToTable("tipoMovimiento");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
            }
        }
