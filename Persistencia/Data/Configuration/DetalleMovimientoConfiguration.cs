using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
            {
                public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
                {
                    builder.ToTable("detalleMovimiento");
        
                    builder.HasKey(e => e.Id);
    
                    builder.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int")
                    .IsRequired();

                    builder.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("double")
                    .IsRequired();

                    builder.HasOne(p => p.Medicamento)
                    .WithMany(p => p.DetalleMovimientos)
                    .HasForeignKey(p => p.IdMedicamentoFk);
                }
            }
