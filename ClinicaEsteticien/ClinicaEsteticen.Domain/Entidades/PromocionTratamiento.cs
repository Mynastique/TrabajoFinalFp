using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class PromocionTratamiento
    {
        public int PromocionId { get; set; }
        public Promocion Promocion { get; set; } = null!;

        public int TratamientoId { get; set; }
        public Tratamientos Tratamiento { get; set; } = null!;
    }
}
