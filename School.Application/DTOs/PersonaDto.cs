using School.Domain.Enums;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace School.Application.DTOs
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public string FechaNacimiento { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Nacionalidades Nacionalidad { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EstadoPersona Estado { get; set; }

        public int RolId { get; set; } 

        //public Roles Roles = new List<Roles>()
   }
}
