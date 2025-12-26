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
    public class ConfiguracionPromocionBono : IEntityTypeConfiguration<PromocionBono>
    {
        public void Configure(EntityTypeBuilder<PromocionBono> builder)
        {
            builder.ToTable("PromocionBono");

            builder.HasKey(x => new { x.PromocionId, x.BonoTratamientoId });

            builder.HasOne(x => x.Promocion)
                .WithMany(p => p.Bonos)
                .HasForeignKey(x => x.PromocionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.BonoTratamiento)
                .WithMany(b => b.Promociones)
                .HasForeignKey(x => x.BonoTratamientoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
