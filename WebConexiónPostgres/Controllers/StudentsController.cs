using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
    
        private readonly ILogger<StudentsController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public StudentsController(
            ILogger<StudentsController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Student estudiante)
        {
            _aplicacionContexto.Student.Add(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //READ: Obtener lista de estudiantes
        
        [Route("")]
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _aplicacionContexto.Student.ToList();
        }
        //Update: Modificar estudiantes
        [Route("student")]
        [HttpPut]
        public IActionResult PutStudent(
            [FromBody] Student estudiante)
        {
            _aplicacionContexto.Student.Update(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //Delete: Eliminar estudiantes
        [Route("student/{estudianteId}")]
        [HttpDelete]
        public IActionResult DeleteStudent(int estudianteId)
        {
            _aplicacionContexto.Student.Remove(
                _aplicacionContexto.Student.ToList()
                .Where(x => x.IdStudent == estudianteId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges ();
            return Ok(estudianteId);
        }
    }
}