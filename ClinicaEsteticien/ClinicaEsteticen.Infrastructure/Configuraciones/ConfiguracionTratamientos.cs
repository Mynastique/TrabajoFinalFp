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
    public class ConfiguracionTratamientos : IEntityTypeConfiguration<Tratamientos>
    {
        public void Configure(EntityTypeBuilder<Tratamientos> builder)
        {
            builder.ToTable("Tratamientos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NombreTratamiento).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(1000);

            builder.Property(x => x.Precio)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DuracionMinutos).IsRequired();

            builder.HasOne(x => x.TipoTratamiento)
                .WithMany(tt => tt.Tratamientos)
                .HasForeignKey(x => x.TipoTratamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Bonos)
                .WithOne(b => b.Tratamiento)
                .HasForeignKey(b => b.TratamientoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
