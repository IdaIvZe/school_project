using School.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class PersonaCredencialesDto
    {
        public string nombreUsuario { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string rol { get; set; } = string.Empty;

    }
}
