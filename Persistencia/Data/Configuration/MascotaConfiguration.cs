using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
        {
            public void Configure(EntityTypeBuilder<Mascota> builder)
            {
                builder.ToTable("mascota");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(e => e.FechaNacimiento)
                .HasColumnName("fechaNacimiento")
                .HasColumnType("date")
                .IsRequired();
                
                builder.HasOne(p => p.Propietario)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(p => p.IdPropietarioFk);

                builder.HasOne(e => e.Raza)
                .WithOne(p => p.Mascota)
                .HasForeignKey<Mascota>(p => p.IdRazaFk);
            }
        }
