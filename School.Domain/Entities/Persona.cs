using School.Domain.Enums;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School.Domain.Entities
{
    public class Persona: ISyncable
    {
        public int Id { get; set; } 
        public Guid IdGlobal { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = string.Empty;
        public Nacionalidades Nacionalidad { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EstadoPersona Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Rol { get; set; } = string.Empty;

        //Propiedades de sincronizacion
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;//TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time"));
        public bool IsDeleted {get; set;} = false;
        public SyncStatus SyncStatus { get; set; } = SyncStatus.Pending;

    }
}
