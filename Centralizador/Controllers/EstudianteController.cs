using AutoMapper;
using Centralizador.DTO;
using Centralizador.Models;
using Centralizador.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Centralizador.Controllers
{
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository repo;
        private readonly IMapper mapper;

        public EstudianteController(IEstudianteRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<EstudianteReadDTO>> GetEstudiantes()
        {
            var estudiantes = repo.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(estudiantes));
        }
        [HttpGet("{id}")]
        public ActionResult<EstudianteReadDTO> GetEstudianteById(int id)
        {
            var estudiante = repo.GetEstudianteById(id);
            if(estudiante != null)
                return Ok(mapper.Map<EstudianteReadDTO>(estudiante));
            return NotFound();
        }
    }
}
