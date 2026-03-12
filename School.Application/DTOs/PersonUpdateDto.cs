using School.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class PersonUpdateDto
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EstadoPersona Estado { get; set; }
        public DateTime FechaActualizacion { get; set; } 
        public SyncStatus SyncStatus { get; set; } 
        public string Rol { get; set; } = string.Empty;
    }
}
