using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
            {
                public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
                {
                    builder.ToTable("movimientoMedicamento");
        
                    builder.HasKey(e => e.Id);
    
                    builder.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int")
                    .IsRequired();

                    builder.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date")
                    .IsRequired();

                    builder.HasOne(p => p.TipoMovimiento)
                    .WithMany(p => p.MovimientoMedicamentos)
                    .HasForeignKey(p => p.IdTipoMovimientoFk);
                }
            }
    