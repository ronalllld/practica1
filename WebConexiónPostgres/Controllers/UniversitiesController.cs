using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.ModelsUniversities;

namespace WebApplication2.ControllersUniversities
{
    [ApiController]
    [Route("[controller]")]
    public class UniversitiesController : ControllerBase
    {
    
        private readonly ILogger<UniversitiesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public UniversitiesController(
            ILogger<UniversitiesController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear Universidad
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] University university)
        {
            _aplicacionContexto.University.Add(university);
            _aplicacionContexto.SaveChanges();
            return Ok(university);
        }
        //READ: Obtener lista de Universidades
       
        [Route("")]
        [HttpGet]
        public IEnumerable<University> GetUniversities()
        {
            return _aplicacionContexto.University.ToList();
        }
        //Update: Modificar universidades
        [Route("university")]
        [HttpPut]
        public IActionResult PutUniversity(
            [FromBody] University university)
        {
            _aplicacionContexto.University.Update(university);
            _aplicacionContexto.SaveChanges();
            return Ok(university);
        }
        //Delete: Eliminar universidades
        [Route("university/{universidadId}")]
        [HttpDelete]
        public IActionResult DeleteUniversity(int universidadId)
        {
            _aplicacionContexto.University.Remove(
                _aplicacionContexto.University.ToList()
                .Where(x => x.IdUniversity == universidadId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges ();
            return Ok(universidadId);
        }
    }
}