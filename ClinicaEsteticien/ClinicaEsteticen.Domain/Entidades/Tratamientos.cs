using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class Tratamientos
    {
        public int Id { get; set; }

        public string NombreTratamiento { get; set; } = null!;
        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }

        // Relationship: many Tratamientos -> one TipoTratamiento
        public int TipoTratamientoId { get; set; }
        public TipoTratamiento TipoTratamiento { get; set; } = null!;

        // Navigation
        public ICollection<BonoTratamiento> Bonos { get; set; } = new List<BonoTratamiento>();
        public ICollection<PromocionTratamiento> Promociones { get; set; } = new List<PromocionTratamiento>();
    }
}
