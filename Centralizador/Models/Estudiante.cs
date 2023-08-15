using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centralizador.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
    }
}
