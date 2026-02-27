using AutoMapper;
using School.Application.DTOs;

using School.Domain;
using School.Domain.Entities;
using School.Application.DTOs;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using School.Application.InterfacesService;
using Microsoft.Extensions.Options;

namespace School.Application.Services
{
    public class PersonaService(IPersonaRepository personaRepository, IMapper mapper): IPersonaService
    {


       public async Task<Persona> crearpersona(PersonaDto dtoPersona)
        {

            var persona = mapper.Map<Persona>(dtoPersona);
            Persona crearPersona = await personaRepository.AddAsync(persona);  

            return crearPersona;
        }


        public async Task<List<PersonaPorRolDto>> getPersonsByRol(string rol)
        {  
            var obtenerPersonas = await personaRepository.getAllByRol(rol);

            List<PersonaPorRolDto> personasRol = new List<PersonaPorRolDto>();


            foreach (Persona personas in obtenerPersonas)
            {
                var personaPorRol = mapper.Map<PersonaPorRolDto>(personas);

                personasRol.Add(personaPorRol);
            } 

            return personasRol; 
        }
 



        public async Task<PersonaCredenciales> getCredential(LoginDto loginData)
        {
            //try
            //{
                if(string.IsNullOrEmpty(loginData.password) && string.IsNullOrEmpty(loginData.userName))
                {
                    return null;
                }

                bool isAuthorized = await personaRepository.validateCredential( loginData.userName, loginData.password);


                if (isAuthorized)
                {
                    return await personaRepository.getCredential(loginData.userName);
                }

                return null;

                

           // }catch(Exception ex)
           // {
           //     throw new InvalidDataException($"Credenciales no cumplen con especificaiones; error tipo: {ex}");
           // }

        }


       public async Task<Persona> updatePersona(int id, PersonUpdateDto objpersonUpdate)
        {

            var personaUpdate = mapper.Map<Persona>(objpersonUpdate);
            await personaRepository.UpdateAsync(id, personaUpdate);

            return personaUpdate;
        }
    }


}

