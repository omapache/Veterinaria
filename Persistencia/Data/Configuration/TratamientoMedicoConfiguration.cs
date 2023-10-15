using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
        {
            public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
            {
                builder.ToTable("tratamientoMedico");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Dosis)
                .HasColumnName("dosis")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(e => e.FechaAdministracion)
                .HasColumnName("fechaAdministracion")
                .HasColumnType("datetime")
                .IsRequired();

                builder.Property(e => e.Observacion)
                .HasColumnName("observacion")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
            }
        }
