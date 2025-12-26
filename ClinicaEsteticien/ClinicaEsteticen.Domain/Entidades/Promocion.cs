using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class Promocion
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

       
        public decimal? DescuentoPorcentaje { get; set; }
        public decimal? DescuentoImporte { get; set; }

        public DateTime FechaInicioUtc { get; set; }
        public DateTime? FechaFinUtc { get; set; }

        public bool Activa { get; set; } = true;

        // Navegacion
        public ICollection<PromocionTratamiento> Tratamientos { get; set; } = new List<PromocionTratamiento>();
        public ICollection<PromocionBono> Bonos { get; set; } = new List<PromocionBono>();
    }
}
