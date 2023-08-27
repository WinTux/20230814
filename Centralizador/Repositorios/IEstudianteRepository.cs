using Centralizador.Models;
namespace Centralizador.Repositorios
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudianteById(int id);

        void AddEstudiante(Estudiante estudiante);

        void UpdateEstudiante(Estudiante estudiante);

        void EliminarEstudiante(Estudiante est);

        bool Guardar();
    }
}
