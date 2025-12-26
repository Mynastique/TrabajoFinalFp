using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEsteticen.Domain.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Municipio { get; set; }

        public string? Provincia { get; set; }

        public string? CodigoPostal { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public bool EsAdmin { get; set; }

        //Navegacion
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
