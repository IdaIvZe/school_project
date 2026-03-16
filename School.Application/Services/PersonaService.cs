using AutoMapper;
using Microsoft.Extensions.Options;
using School.Application.DTOs;
using School.Application.DTOs;
using School.Application.InterfacesService;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School.Application.Services
{
    public class PersonaService(IPersonaRepository personaRepository, IMapper mapper): IPersonaService
    {


       public async Task<Persona> Crearpersona(PersonaDto dtoPersona)
        {

            var persona = mapper.Map<Persona>(dtoPersona);
            Persona crearPersona = await personaRepository.AddAsync(persona);  

            return crearPersona;
        }

        //List<PersonaPorRolDto>
        public async Task<PaginacionResponse<PersonaPorRolDto>> GetPersonsByRol(string rol, int page, int size)
        {  
            var obtenerPersonas = await personaRepository.GetAllByRol(rol, page, size);

            List<PersonaPorRolDto> personasRol = new List<PersonaPorRolDto>();

            if (obtenerPersonas.Datos == null || obtenerPersonas.Datos.Count == 0) {
                return null;
            }
            
            foreach (Persona personas in obtenerPersonas.Datos)
            {
                var personaPorRol = mapper.Map<PersonaPorRolDto>(personas);

                personasRol.Add(personaPorRol);
            }

            return new PaginacionResponse<PersonaPorRolDto>
            {
                Datos = personasRol,
                PaginaActual = obtenerPersonas.PaginaActual,
                TamañoPagina = obtenerPersonas.TamañoPagina,
                TotalRegistros = obtenerPersonas.TotalRegistros,
                TotalPaginas = obtenerPersonas.TotalPaginas,
                TieneAnterior = obtenerPersonas.TieneAnterior,
                TieneSiguiente = obtenerPersonas.TieneSiguiente
            };


        }
 



        public async Task<PersonaCredenciales> GetCredential(LoginDto loginData)
        {
            //try
            //{
                if(string.IsNullOrEmpty(loginData.Password) && string.IsNullOrEmpty(loginData.UserName))
                {
                    return null;
                }

                bool isAuthorized = await personaRepository.ValidateCredential( loginData.UserName, loginData.Password);


                if (isAuthorized)
                {
                    return await personaRepository.GetCredential(loginData.UserName);
                }

                return null;

                

           // }catch(Exception ex)
           // {
           //     throw new InvalidDataException($"Credenciales no cumplen con especificaiones; error tipo: {ex}");
           // }

        }


       public async Task<Persona> UpdatePersona(int id, PersonUpdateDto objpersonUpdate)
        {

            var personaUpdate = mapper.Map<Persona>(objpersonUpdate);
            await personaRepository.UpdateAsync(id, personaUpdate);

            return personaUpdate;
        }

        public async Task<PersonUpdateDto> GetByIdAsync(int id)
        {

            var persona = mapper.Map<PersonUpdateDto>(await personaRepository.GetByIdAsync(id));
            return persona;

           
        }
    }


}

