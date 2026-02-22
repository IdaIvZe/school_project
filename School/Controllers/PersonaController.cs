


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs;
using School.Application.Services;
using School.Application.InterfacesService;

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
        public async Task<ActionResult> crearPersona([FromBody] PersonaDto dtoPersona)
        {

            var obj = await _personService.crearpersona(dtoPersona);
            return Ok(obj);
                
        }


        [HttpGet("/personas/rol/{rol}")]
        public async Task<ActionResult> obtenerPersonasPorRol( string rol)
        {

            List<PersonaPorRolDto> personasRol = await _personService.obtenerPersonasPorRol(rol);

            return Ok(personasRol);
        }


        [HttpPost("/login")]
        public async Task<ActionResult> validarCredencaialesUsuario(string password, string nombreUsuario)
        {

            PersonaCredencialesDto credencialesUsuario = await _personService.validarCredenciales(password, nombreUsuario);

            return Ok(credencialesUsuario);
        }

    }
}
