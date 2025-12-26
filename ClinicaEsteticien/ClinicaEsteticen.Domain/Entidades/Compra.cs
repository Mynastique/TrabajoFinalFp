using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class Compra
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } = null!;

        public int? TratamientoId { get; set; }
        public Tratamientos? Tratamiento { get; set; }

        public int? BonoTratamientoId { get; set; }
        public BonoTratamiento? BonoTratamiento { get; set; }

        public DateTime FechaCompraUtc { get; set; }
        public int Cantidad { get; set; } = 1;

        // Instantánea del precio realmente pagado (importante para promociones/descuentos e historial)
        public decimal PrecioUnitarioPagado { get; set; }
        public decimal TotalPagado { get; set; }

        public string? Observaciones { get; set; }
    }
}
