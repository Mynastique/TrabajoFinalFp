using ClinicaEsteticen.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClinicaEsteticen.Infrastructure.ContextoBaseDeDatos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Core
        public DbSet<Usuarios> Usuarios { get; set; } = null!;
        public DbSet<TipoTratamiento> TipoTratamientos { get; set; } = null!;
        public DbSet<Tratamientos> Tratamientos { get; set; } = null!;

        // Bonos / Compras
        public DbSet<BonoTratamiento> BonosTratamientos { get; set; } = null!;
        public DbSet<Compra> Compras { get; set; } = null!;

        // Promociones
        public DbSet<Promocion> Promociones { get; set; } = null!;
        public DbSet<PromocionTratamiento> PromocionTratamientos { get; set; } = null!;
        public DbSet<PromocionBono> PromocionBonos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration<T> in this assembly (Infrastructure)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
