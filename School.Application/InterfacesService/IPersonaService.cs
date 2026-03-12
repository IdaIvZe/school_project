using School.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Entities;
// School.Domain.DTOs;
using School.Application.DTOs.ApiResponse;
using School.Application.DTOs;

namespace School.Application.InterfacesService
{
    public interface IPersonaService
    {

        Task<Persona> Crearpersona(PersonaDto dtoPersona);

        Task<List<PersonaPorRolDto>> GetPersonsByRol(string rol);

        Task<PersonaCredenciales> GetCredential( LoginDto loginData);

        Task<Persona> UpdatePersona(int id, PersonUpdateDto objpersonUpdate);

        Task<PersonUpdateDto> GetByIdAsync(int id);
    }
}
