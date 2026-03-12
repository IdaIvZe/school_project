


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
        public async Task<ActionResult<PersonaDto>> CrearPersona([FromBody] PersonaDto dtoPersona)
        {

            var obj = await _personService.Crearpersona(dtoPersona);

           

            return Ok(obj);
                
        }


        [HttpGet("/personas/rol/{rol}")]
        public async Task<ActionResult<ApiResponseDto<List<PersonaDto>>>> ObtenerPersonasPorRol( string rol)
        {

           var personasRol = await _personService.GetPersonsByRol(rol);

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
        public async Task<ActionResult> ValidarCredencaialesUsuario([FromBody] LoginDto loginData)
        {
            var credencialesUsuario = await _personService.GetCredential( loginData);

            return Ok(credencialesUsuario);
        }

        [HttpPatch("/update/{id}")]
        public async Task<ActionResult> UpdatePerson(int id, PersonUpdateDto personUpdate)
        {
            var personUpdated = await _personService.UpdatePersona(id, personUpdate);

            return Ok(personUpdated);
        }

        [HttpGet("/persona/{id}")]
        public async Task<ActionResult> GetPersonaById(int id)
        {
            PersonUpdateDto persona = await _personService.GetByIdAsync(id);

            return Ok(persona);
        }
    }
}
