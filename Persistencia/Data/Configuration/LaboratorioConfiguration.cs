using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
        {
            public void Configure(EntityTypeBuilder<Laboratorio> builder)
            {
                builder.ToTable("laboratorio");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(e => e.Direccion)
                .HasColumnName("direccion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
            }
        }

