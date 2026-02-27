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

        Task<Persona> crearpersona(PersonaDto dtoPersona);

        Task<List<PersonaPorRolDto>> getPersonsByRol(string rol);

        Task<PersonaCredenciales> getCredential( LoginDto loginData);

        Task<Persona> updatePersona(int id, PersonUpdateDto objpersonUpdate);
    }
}
