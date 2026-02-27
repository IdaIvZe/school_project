using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class PersonaCredenciales
    {
        public string nombreUsuario { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string nombres { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string rol { get; set; } = string.Empty;
    }
}
