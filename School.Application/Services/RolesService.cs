using AutoMapper;
using School.Application.DTOs;
using School.Application.InterfacesService;
using School.Domain.Entities;
using School.Domain.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School.Application.Services
{
    public class RolesService: IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;
        public RolesService(IRolesRepository rolesRepository, IMapper mapper  )
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;

        }
        public async Task<List<RolesDto>> GetRolesAsync()
        {
           var roles = await _rolesRepository.GetAllRolesAsync();
           List<RolesDto> rolesDto = _mapper.Map<List<RolesDto>>(roles);
            
           return rolesDto;
        }

    }
}
