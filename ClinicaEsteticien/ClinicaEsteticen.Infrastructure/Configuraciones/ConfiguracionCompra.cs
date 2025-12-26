using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaEsteticen.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaEsteticen.Infrastructure.Configuraciones
{
    public class ConfiguracionCompra : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaCompraUtc).IsRequired();

            builder.Property(x => x.PrecioUnitarioPagado)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.TotalPagado)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Cantidad).IsRequired();
            builder.Property(x => x.Observaciones).HasMaxLength(500);

            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tratamiento)
                .WithMany()
                .HasForeignKey(x => x.TratamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BonoTratamiento)
                .WithMany(b => b.Compras)
                .HasForeignKey(x => x.BonoTratamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ensure exactly one of TratamientoId or BonoTratamientoId is provided
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Compra_TratamientoOrBono",
                "((TratamientoId IS NOT NULL AND BonoTratamientoId IS NULL) OR (TratamientoId IS NULL AND BonoTratamientoId IS NOT NULL))"
            ));
        }
    }
}
