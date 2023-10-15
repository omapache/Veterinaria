using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class RazaConfiguration : IEntityTypeConfiguration<Raza>
        {
            public void Configure(EntityTypeBuilder<Raza> builder)
            {
                builder.ToTable("raza");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder.HasOne(p => p.Especie)
                .WithMany(p => p.Razas)
                .HasForeignKey(p => p.IdEspecieFk);
            }
        }
