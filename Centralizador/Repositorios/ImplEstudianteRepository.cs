using Centralizador.Models;

namespace Centralizador.Repositorios
{
    public class ImplEstudianteRepository : IEstudianteRepository
    {
        private readonly UniversidadDbContext cont;
        public ImplEstudianteRepository(UniversidadDbContext cont)
        {
            this.cont = cont;
        }
        public Estudiante GetEstudianteById(int id)
        {
            return cont.Estudiantes.FirstOrDefault(est => est.id == id);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            
            return cont.Estudiantes.ToList();
        }
    }
}
