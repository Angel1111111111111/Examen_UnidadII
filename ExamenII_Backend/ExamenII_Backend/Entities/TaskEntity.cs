using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenII_Backend.Entities
{
    [Table("calculator", Schema = "patiens")]
    public class TaskEntity
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
