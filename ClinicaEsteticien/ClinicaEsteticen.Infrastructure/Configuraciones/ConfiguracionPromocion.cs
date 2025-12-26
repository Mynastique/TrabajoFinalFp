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
    public class ConfiguracionPromocion : IEntityTypeConfiguration<Promocion>
    {
        public void Configure(EntityTypeBuilder<Promocion> builder)
        {
            builder.ToTable("Promocion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(1000);

            builder.Property(x => x.DescuentoPorcentaje).HasPrecision(18, 2);
            builder.Property(x => x.DescuentoImporte).HasPrecision(18, 2);

            builder.Property(x => x.FechaInicioUtc).IsRequired();
            builder.Property(x => x.Activa).IsRequired();
        }
    }
}
