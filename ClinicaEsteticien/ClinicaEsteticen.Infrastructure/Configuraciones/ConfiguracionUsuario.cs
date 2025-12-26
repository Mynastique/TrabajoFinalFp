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
    public class ConfiguracionUsuario : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Apellidos).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(500).IsRequired(); // Store hash, not plain text

            builder.Property(x => x.Municipio).HasMaxLength(120);
            builder.Property(x => x.Provincia).HasMaxLength(120);
            builder.Property(x => x.CodigoPostal).HasMaxLength(10);
            builder.Property(x => x.Direccion).HasMaxLength(250);
            builder.Property(x => x.Telefono).HasMaxLength(30);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Compras)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
