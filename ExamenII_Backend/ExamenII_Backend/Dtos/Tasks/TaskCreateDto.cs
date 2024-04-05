using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenII_Backend.Dtos.Tasks
{
    public class TaskCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerida")]
        [StringLength(maximumLength: 250,
            MinimumLength = 10,
            ErrorMessage = "El {0} debe tener entre {2} a {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Genero")]
        [Required]
        public string Genero { get; set; }

        [Display(Name = "Peso")]
        [Required]
        public int Peso { get; set; }

        [Display(Name = "Altura")]
        [Required]
        public decimal Altura { get; set; }

        public decimal Resultado { get; set; }
    }
}
