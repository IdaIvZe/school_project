using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Roles
    {
        public int IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? CodigoRol { get; set; }
        public string? DescripcionRol { get; set; }

        public ICollection<Persona> Personas { get; set; } = new List<Persona>();

    }
}
