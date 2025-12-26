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
    public class ConfiguracionBonoTratamiento : IEntityTypeConfiguration<BonoTratamiento>
    {
        public void Configure(EntityTypeBuilder<BonoTratamiento> builder)
        {
            builder.ToTable("BonoTratamiento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(150).IsRequired();
            builder.Property(x => x.NumeroSesiones).IsRequired();

            builder.Property(x => x.Precio)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Activo).IsRequired();

            builder.HasOne(x => x.Tratamiento)
                .WithMany(t => t.Bonos)
                .HasForeignKey(x => x.TratamientoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Compras)
                .WithOne(c => c.BonoTratamiento)
                .HasForeignKey(c => c.BonoTratamientoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
