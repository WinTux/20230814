using Centralizador.Models;
using Microsoft.EntityFrameworkCore;

namespace Centralizador.Repositorios
{
    public class UniversidadDbContext : DbContext
    {
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options) : base(options)
        {
            
        }
    }
}
