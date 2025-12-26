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
    public class ConfiguracionTipoTratamiento : IEntityTypeConfiguration<TipoTratamiento>
    {
        public void Configure(EntityTypeBuilder<TipoTratamiento> builder)
        {
            builder.ToTable("TipoTratamiento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);

            builder.HasMany(x => x.Tratamientos)
                .WithOne(t => t.TipoTratamiento)
                .HasForeignKey(t => t.TipoTratamientoId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid deleting a type and cascading to treatments
        }
    }
}
