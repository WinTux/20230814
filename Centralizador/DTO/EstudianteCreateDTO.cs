using System.ComponentModel.DataAnnotations;

namespace Centralizador.DTO
{
    public class EstudianteCreateDTO
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
    }
}
