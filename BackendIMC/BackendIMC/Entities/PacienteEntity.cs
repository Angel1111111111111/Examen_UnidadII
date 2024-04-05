using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendIMC.Entities
{
    [Table("tasks", Schema = "transactional")]
    public class PacienteEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Column("género")]
        [Required]
        [StringLength(50)]
        public string Genero { get; set; }

        [Column("peso")]
        [Required]
        public int Peso { get; set; }

        [Column("altura")]
        [Required]
        public decimal Altura { get; set; }

        [Column("resultado")]
        [Required]
        public decimal Resultado { get; set; }
    }
}