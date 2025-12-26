using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class PromocionBono
    {
        public int PromocionId { get; set; }
        public Promocion Promocion { get; set; } = null!;

        public int BonoTratamientoId { get; set; }
        public BonoTratamiento BonoTratamiento { get; set; } = null!;
    }
}
