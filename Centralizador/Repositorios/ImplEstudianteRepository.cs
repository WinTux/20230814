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

        public void AddEstudiante(Estudiante estudiante)
        {
            if (estudiante == null) throw new ArgumentNullException(nameof(estudiante));
            cont.Estudiantes.Add(estudiante);
        }

        public Estudiante GetEstudianteById(int id)
        {
            return cont.Estudiantes.FirstOrDefault(est => est.id == id);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            
            return cont.Estudiantes.ToList();
        }

        public bool Guardar()
        {
            return (cont.SaveChanges() > -1);
        }

        public void UpdateEstudiante(Estudiante estudiante)
        {
            //No hacemos nada pues será gestionado por el DbContext
        }
    }
}
