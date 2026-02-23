using School.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Entities;
using School.Application.DTOs.ApiResponse;

namespace School.Application.InterfacesService
{
    public interface IPersonaService
    {

        Task<Persona> crearpersona(PersonaDto dtoPersona);

        Task<List<PersonaPorRolDto>> obtenerPersonasPorRol(string rol);

        Task<PersonaCredencialesDto> validarCredenciales(string password, string username);
    }
}
