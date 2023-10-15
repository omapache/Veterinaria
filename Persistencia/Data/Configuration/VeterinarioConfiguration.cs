using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
            {
                public void Configure(EntityTypeBuilder<Veterinario> builder)
                {
                    builder.ToTable("veterinarios");
        
                    builder.HasKey(e => e.Id);
    
                    builder.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsRequired();

                    builder.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsRequired();

                    builder.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .IsRequired();

                    builder.Property(e => e.Especialidad)
                    .HasColumnName("especialidad")
                    .HasMaxLength(250)
                    .IsRequired();
                }
            }
