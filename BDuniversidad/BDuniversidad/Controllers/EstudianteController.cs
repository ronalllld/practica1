using BDuniversidad.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BDuniversidad.controllers.UniversidadController;

namespace BDuniversidad.Controllers
{
    public class EstudianteController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class EstudiantesController : ControllerBase
        {
            // Similar a los ejemplos anteriores, pero reemplaza "Universidad" por "Estudiante"
            private readonly ILogger<UniversidController> _logger;
            private readonly DbContext _aplicacionContexto;
            private object existingEstudiantes;

            public EstudiantesController(
                ILogger<EstudianteController> logger,
                DbContext aplicacionContexto)
            {
                _logger = (ILogger<UniversidController>?)logger;
                _aplicacionContexto = aplicacionContexto;
            }

            // Create: Crear una universidad
            [HttpPost]
            public IActionResult Post([FromBody] Universidad Estudiantes)
            {
                _aplicacionContexto.Estudiantes.Add(Estudiantes);
                _aplicacionContexto.SaveChanges();
                return Ok(Estudiantes);
            }

            // Read: Obtener lista de universidades
            [HttpGet]
            public IEnumerable<Universidad> Get()
            {
                return _aplicacionContexto.Estudiantes.ToList();
            }

            // Update: Modificar una universidad por su ID
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Estudiante estudiantes, Estudiante estudiante)
            {
                var existingUniversidad = _aplicacionContexto.Estudiantes.FirstOrDefault(u => u.IdUniversidad == id);

                if (existingUniversidad == null)
                {
                    return NotFound();
                }

                existingEstudiantes.nombre = estudiante.Nombre;
                // Agrega otras propiedades que desees actualizar

                _aplicacionContexto.SaveChanges();
                return Ok(existingEstuidantes);
            }

            private IActionResult Ok(object existingEstuidantes)
            {
                throw new NotImplementedException();
            }

            // Delete: Eliminar una universidad por su ID
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var universidad = _aplicacionContexto.Estudiantes.FirstOrDefault(u => u.IdUniversidad == id);

                if (universidad == null)
                {
                    return NotFound();
                }

                _aplicacionContexto.Estudiantes.Remove(universidad);
                _aplicacionContexto.SaveChanges();
                return Ok(id);
            }
        }

    }
}
