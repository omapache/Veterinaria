using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
        {
            public void Configure(EntityTypeBuilder<Cita> builder)
            {
                builder.ToTable("cita");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("Date")
                .IsRequired();

                 builder.Property(e => e.Hora)
                .HasColumnName("hora")
                .HasColumnType("Datetime")
                .IsRequired();

                builder.Property(e => e.Motivo)
                .HasColumnName("motivo")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.HasOne(p => p.Veterinario)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.IdVeterinarioFk);

                builder.HasOne(p => p.Mascota)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.IdMascotaFk);
            }
        }

