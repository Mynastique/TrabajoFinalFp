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
    public class ConfiguracionPromocionTratamiento : IEntityTypeConfiguration<PromocionTratamiento>
    {
        public void Configure(EntityTypeBuilder<PromocionTratamiento> builder)
        {
            builder.ToTable("PromocionTratamiento");

            builder.HasKey(x => new { x.PromocionId, x.TratamientoId });

            builder.HasOne(x => x.Promocion)
                .WithMany(p => p.Tratamientos)
                .HasForeignKey(x => x.PromocionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tratamiento)
                .WithMany(t => t.Promociones)
                .HasForeignKey(x => x.TratamientoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
