using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
        {
            public void Configure(EntityTypeBuilder<Propietario> builder)
            {
                builder.ToTable("propietario");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

                builder.Property(e => e.Telefono)
                .IsRequired();
            }
        }
