using System.ComponentModel.DataAnnotations;

namespace Centralizador.DTO
{
    public class EstudianteUpdateDTO
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
    }
}
