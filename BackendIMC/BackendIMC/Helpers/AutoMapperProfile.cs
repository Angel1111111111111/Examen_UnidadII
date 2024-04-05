using AutoMapper;
using BackendIMC.Dtos.Patiens;
using BackendIMC.Entities;

namespace BackendIMC.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForPatiens();
        }

        private void MapsForPatiens()
        {
            CreateMap<PacienteEntity, PacienteDto>();
        }
    }
}

