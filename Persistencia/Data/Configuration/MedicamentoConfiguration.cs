using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
        {
            public void Configure(EntityTypeBuilder<Medicamento> builder)
            {
                builder.ToTable("medicamento");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(e => e.CantidadDisponible)
                .HasColumnName("cantidadDisponible")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(e => e.Precio)
                .HasColumnName("precio")
                .HasColumnType("int")
                .IsRequired();

                builder.HasOne(p => p.Laboratorio)
                .WithMany(p => p.Medicamentos)
                .HasForeignKey(p => p.IdLaboratorioFk);
            }
        }
