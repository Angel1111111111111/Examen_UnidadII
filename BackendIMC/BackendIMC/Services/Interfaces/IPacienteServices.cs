using BackendIMC.Dtos;
using BackendIMC.Dtos.Patiens;
using Microsoft.EntityFrameworkCore;

namespace BackendIMC.Services.Interfaces
{
    public interface IPacienteServices
    {
        Task<ResponseDto<PacienteDto>> GetPacienteByIdAsync(Guid id);
        Task<ResponseDto<List<PacienteDto>>> GetPacientesAsync(string searchTerm = "");
    }
}
