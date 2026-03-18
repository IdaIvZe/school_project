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
            //CreateMap<Persona, PersonaDto>().ForMember(destino => destino.RolId,
            //   opciones => opciones.Ignore());
            //CreateMap<PersonaDto, Persona>()
            //    .ForMember(destino => destino.Roles,                    
            //               opciones => opciones.MapFrom( fuente => fuente.RolId > 0               
            //                                                     ? new List<Roles> { new Roles { IdRol = fuente.RolId } }
            //                                                     : new List<Roles>()));

            CreateMap<PersonaDto, Persona>()
            .ForMember(dest => dest.Roles,
                       opt => opt.MapFrom(src => src.RolId > 0
                           ? new List<Roles> { new Roles { IdRol = src.RolId } }
                           : new List<Roles>()));

            // Salida: Persona → DTO (para respuestas API)
            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.RolId,
                           opt => opt.MapFrom(src =>
                               src.Roles.Select(r => r.IdRol).FirstOrDefault()))
                .ForMember(dest => dest.RolId,
                           opt => opt.Ignore());

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
