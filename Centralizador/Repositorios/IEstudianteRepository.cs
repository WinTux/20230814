using Centralizador.Models;
namespace Centralizador.Repositorios
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudianteById(int id);
    }
}
