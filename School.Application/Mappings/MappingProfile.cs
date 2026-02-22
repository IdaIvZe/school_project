using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.Application.DTOs;
using School.Domain.Entities;


namespace School.Application.Mappings
{
    public class MappingProfile: Profile
    {



        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            CreateMap<PersonaPorRolDto, Persona>();
            CreateMap< Persona, PersonaPorRolDto>();

            CreateMap<PersonaCredencialesDto, Persona>();
            CreateMap<Persona, PersonaCredencialesDto>();


        }

    }

       
}
