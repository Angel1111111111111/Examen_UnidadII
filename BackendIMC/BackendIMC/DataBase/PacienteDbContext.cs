using BackendIMC.Dtos.Patiens;
using BackendIMC.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BackendIMC.DataBase
{
    public class PacienteDbContext : DbContext
    {
        public PacienteDbContext(DbContextOptions<PacienteDbContext> options) : base(options)
        {

        }

        public DbSet<PacienteDto> Pacientes { get; set; }

        
    }
}
