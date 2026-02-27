


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs;
//using School.Domain.DTOs;
using School.Application.Services;
using School.Application.InterfacesService;
using School.Application.DTOs.ApiResponse;
namespace School.Api.Controllers
{

    [ApiController]
    [Route("/[Controller]")]
    public class PersonaController: ControllerBase
    {

        public readonly IMapper _mapper;
        private readonly IPersonaService _personService;

        public PersonaController(IMapper mapper, IPersonaService personaService) {
            _mapper = mapper;
            _personService = personaService;
            
        }


        [HttpPost("/registrar")]
        public async Task<ActionResult<PersonaDto>> crearPersona([FromBody] PersonaDto dtoPersona)
        {

            var obj = await _personService.crearpersona(dtoPersona);

           

            return Ok(obj);
                
        }


        [HttpGet("/personas/rol/{rol}")]
        public async Task<ActionResult<ApiResponseDto<List<PersonaDto>>>> obtenerPersonasPorRol( string rol)
        {

           var personasRol = await _personService.getPersonsByRol(rol);

            var response = new ApiResponseDto<List<PersonaPorRolDto>>
            {
                
                Status = 200,
                Data = personasRol,
                Success = true,
                Message = "Lista de personas obtenida exitosamente"

            };
            
            return Ok(response);
        }


        [HttpPost("/login")]
        public async Task<ActionResult> validarCredencaialesUsuario([FromBody] LoginDto loginData)
        {
            var credencialesUsuario = await _personService.getCredential( loginData);

            return Ok(credencialesUsuario);
        }

        [HttpPatch("/update")]
        public async Task<ActionResult> updatePerson(int id, PersonUpdateDto personUpdate)
        {
            var personUpdated = await _personService.updatePersona(id, personUpdate);

            return Ok(personUpdated);
        }
    }
}
