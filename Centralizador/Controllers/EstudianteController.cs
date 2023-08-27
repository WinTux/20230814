using AutoMapper;
using Azure;
using Centralizador.DTO;
using Centralizador.Models;
using Centralizador.Repositorios;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetEstudianteById")]
        public ActionResult<EstudianteReadDTO> GetEstudianteById(int id)
        {
            var estudiante = repo.GetEstudianteById(id);
            if(estudiante != null)
                return Ok(mapper.Map<EstudianteReadDTO>(estudiante));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<EstudianteReadDTO> SetEstudiante(EstudianteCreateDTO estudianteCreateDTO)
        {
            Estudiante estudiante = mapper.Map<Estudiante>(estudianteCreateDTO);
            repo.AddEstudiante(estudiante);
            repo.Guardar();
            EstudianteReadDTO estRetorno = mapper.Map<EstudianteReadDTO>(estudiante);
            return CreatedAtRoute(nameof(GetEstudianteById), new { id = estudiante.id }, estRetorno);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEstudiante(int id, EstudianteUpdateDTO estudianteUpdateDTO) {
            Estudiante estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            mapper.Map(estudianteUpdateDTO, estudiante);
            repo.UpdateEstudiante(estudiante);
            repo.Guardar();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateParcialEstudiante(int id, JsonPatchDocument<EstudianteUpdateDTO> estudiantePatch)
        {
            Estudiante estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            EstudianteUpdateDTO estParaPatch = mapper.Map<EstudianteUpdateDTO>(estudiante);
            estudiantePatch.ApplyTo(estParaPatch, ModelState);
            if (!TryValidateModel(estParaPatch))
                return ValidationProblem(ModelState);
            mapper.Map(estParaPatch, estudiante);
            repo.UpdateEstudiante(estudiante);
            repo.Guardar();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarEstudiante(int id)
        {
            Estudiante estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            repo.EliminarEstudiante(estudiante);
            repo.Guardar();
            return NoContent();
        }
    }
}
