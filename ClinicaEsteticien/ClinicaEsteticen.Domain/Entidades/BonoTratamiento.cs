using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class BonoTratamiento
    {
        public int Id { get; set; }

        public int TratamientoId { get; set; }
        public Tratamientos Tratamiento { get; set; } = null!;

        public string Nombre { get; set; } = null!;      
        public int NumeroSesiones { get; set; }          
        public decimal Precio { get; set; }              

        public bool Activo { get; set; } = true;

        // Navegacion
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
        public ICollection<PromocionBono> Promociones { get; set; } = new List<PromocionBono>();
    }
}
