using BackendIMC.Dtos;
using BackendIMC.Dtos.Patiens;
using BackendIMC.Services;
using BackendIMC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendIMC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteServices _pacienteServices; 

        public PacientesController(
            IPacienteServices pacienteServices
            )
        {
            _pacienteServices = pacienteServices;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PacienteDto>>>> GetAll(string searchTerm = "")
        {
            var pacientesResponse = await _pacienteServices.GetPacientesAsync(searchTerm);
            return StatusCode(pacientesResponse.StatusCode, pacientesResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PacienteDto>>> GetOneById(Guid id)
        {
            var pacienteResponse = await _pacienteServices.GetPacienteByIdAsync(id);
            return StatusCode(pacienteResponse.StatusCode, pacienteResponse);
        }
    }
}
