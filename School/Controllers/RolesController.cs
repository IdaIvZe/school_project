using Microsoft.AspNetCore.Mvc;
using School.Application.InterfacesService;
using School.Application.DTOs.ApiResponse;
using School.Application.DTOs;


namespace School.Api.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class RolesController : Controller
    {

        private readonly IRolesService _rolesService;
        
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }


        [HttpGet("/roles")]
        public async Task<ActionResult<ApiResponseDto<List<RolesDto>>>> GetRolesPersonas()
        {

            var rolesPersonas = await _rolesService.GetRolesAsync();
            var response = new ApiResponseDto<List<RolesDto>>
            {

                Status = 200,
                Data = rolesPersonas,
                Success = true,
                Message = "Lista de personas obtenida exitosamente"

            };

            return Ok(response);

        }
        
    }
}
