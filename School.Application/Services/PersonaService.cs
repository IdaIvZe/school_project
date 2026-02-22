using AutoMapper;
using School.Application.DTOs;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using School.Application.InterfacesService;

namespace School.Application.Services
{
    public class PersonaService(IPersonaRepository personaRepository, IMapper mapper): IPersonaService
    {


       public async Task<Persona> crearpersona(PersonaDto dtoPersona)
        {

            var persona = mapper.Map<Persona>(dtoPersona);
            var crearPersona = await personaRepository.crearPersona(persona);  

            return crearPersona;
        }

        public async Task<List<PersonaPorRolDto>> obtenerPersonasPorRol(string rol)
        {
            //var persona = mapper.Map<Persona>(dtoPersonaPorRol);
            
            var obtenerPersonas = await personaRepository.obtenerPersonasPorRol(rol);

            List<PersonaPorRolDto> personasRol = new List<PersonaPorRolDto>();


            foreach (Persona personas in obtenerPersonas)
            {
                var personaPorRol = mapper.Map<PersonaPorRolDto>(personas);

                personasRol.Add(personaPorRol);
            } 

            return personasRol; 
        }
 



        public async Task<PersonaCredencialesDto> validarCredenciales(string password, string nombreUsuario)
        {
            try
            {

                Persona credencialesValidas = await personaRepository.validarCredenciales(password, nombreUsuario);

                var objCredenciales = mapper.Map<PersonaCredencialesDto>(credencialesValidas);

                return objCredenciales;


            }catch(Exception ex)
            {
                throw new InvalidDataException($"Credenciales no cumplen con especificaiones; error tipo: {ex}");
            }

        }
         

    }
}
