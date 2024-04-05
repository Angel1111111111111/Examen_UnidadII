using AutoMapper;
using BackendIMC.Dtos.Patiens;
using BackendIMC.Dtos;
using BackendIMC.Services.Interfaces;
using BackendIMC.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackendIMC.Services
{
    public class PacienteServices : IPacienteServices
    {
        private readonly PacienteDbContext _context;
        private readonly IMapper _mapper;

        public PacienteServices(
            PacienteDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<PacienteDto>>> GetPacientesAsync(string searchTerm = "")
        {
            var pacientesEntity = await _context.Pacientes
                .Where(p => p.Nombre.Contains(searchTerm))
                .ToListAsync();

            var pacientesDto = _mapper.Map<List<PacienteDto>>(pacientesEntity);

            return new ResponseDto<List<PacienteDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Datos obtenidos correctamente",
                Data = pacientesDto
            };
        }

        public async Task<ResponseDto<PacienteDto>> GetPacienteByIdAsync(Guid id)
        {
            var pacienteEntity = await _context.Pacientes.FindAsync(id);

            if (pacienteEntity == null)
            {
                return new ResponseDto<PacienteDto>
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"Paciente con ID {id} no encontrado"
                };
            }

            var pacienteDto = _mapper.Map<PacienteDto>(pacienteEntity);

            return new ResponseDto<PacienteDto>
            {
                Status = true,
                StatusCode = 200,
                Message = "Paciente encontrado",
                Data = pacienteDto
            };
        }

    }
}
