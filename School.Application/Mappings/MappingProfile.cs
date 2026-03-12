using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.Application.DTOs;
using School.Application.Services;
using School.Domain.Entities;


namespace School.Application.Mappings
{
    public class MappingProfile : Profile
    {



        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            CreateMap<PersonaPorRolDto, Persona>();
            CreateMap<Persona, PersonaPorRolDto>();

            CreateMap<PersonaCredenciales, PersonaCredencialesDto>();
            CreateMap<PersonaCredencialesDto, PersonaCredenciales>();

            CreateMap<Persona, PersonUpdateDto>();
            CreateMap<PersonUpdateDto, Persona>();

            CreateMap<RolesDto, Roles>();
            CreateMap<Roles, RolesDto>();

        }

    }


}
