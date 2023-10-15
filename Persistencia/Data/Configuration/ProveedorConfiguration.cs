using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
        {
            public void Configure(EntityTypeBuilder<Proveedor> builder)
            {
                builder.ToTable("proveedor");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder
                .HasMany(p => p.Medicamentos)
                .WithMany(p => p.Proveedores)
                .UsingEntity<MedicamentoProveedor>(
                  j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.IdMedicamentoFk),
                  j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.IdProveedorFk),
                  j => 
                    {
                      j.HasKey(t => new {t.IdProveedorFk, t.IdMedicamentoFk});
                    });
            }
        }
/*dotnet ef database update --project ./Persistencia/ --startup-project ./API/
 */