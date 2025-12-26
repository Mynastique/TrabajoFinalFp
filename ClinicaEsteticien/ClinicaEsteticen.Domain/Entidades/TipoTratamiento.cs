using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class TipoTratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        //Navegacion
        public ICollection<Tratamientos> Tratamientos { get; set; } = new List<Tratamientos>();
    }
}
