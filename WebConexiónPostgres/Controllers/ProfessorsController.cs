using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.ModelsProfessor;

namespace WebApplication2.ControllersProffesor
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorsController : ControllerBase
    {
    
        private readonly ILogger<ProfessorsController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public ProfessorsController(
            ILogger<ProfessorsController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear Docente
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Professor professor)
        {
            _aplicacionContexto.Professor.Add(professor);
            _aplicacionContexto.SaveChanges();
            return Ok(professor);
        }
        //READ: Obtener lista de Docentes
       
        [Route("")]
        [HttpGet]
        public IEnumerable<Professor> GetProfessors()
        {
            return _aplicacionContexto.Professor.ToList();
        }
        //Update: Modificar docentes
        [Route("professor")]
        [HttpPut]
        public IActionResult PutProfessor(
            [FromBody] Professor professor)
        {
            _aplicacionContexto.Professor.Update(professor);
            _aplicacionContexto.SaveChanges();
            return Ok(professor);
        }
        //Delete: Eliminar docentes
        [Route("professor/{docenteId}")]
        [HttpDelete]
        public IActionResult DeleteProfessor(int docenteId)
        {
            _aplicacionContexto.Professor.Remove(
                _aplicacionContexto.Professor.ToList()
                .Where(x => x.IdProfessor == docenteId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges ();
            return Ok(docenteId);
        }
    }
}