using Microsoft.AspNetCore.Mvc;
using BDuniversidad.context;
using BDuniversidad.models;
using Microsoft.EntityFrameworkCore;

namespace BDuniversidad.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversidadesController : ControllerBase
    {
        private readonly ILogger<UniversidadesController> _logger;
        private readonly DbContext _aplicacionContexto;

        public UniversidadesController(
            ILogger<UniversidadesController> logger,
            DbContext aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear una universidad
        [HttpPost]
        public IActionResult Post([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidades.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }

        // Read: Obtener lista de universidades
        [HttpGet]
        public IEnumerable<Universidad> Get()
        {
            return _aplicacionContexto.Universidades.ToList();
        }

        // Update: Modificar una universidad por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Universidad universidad)
        {
            var existingUniversidad = _aplicacionContexto.Universidades.FirstOrDefault(u => u.IdUniversidad == id);

            if (existingUniversidad == null)
            {
                return NotFound();
            }

            existingUniversidad.Nombre = universidad.Nombre;
            // Agrega otras propiedades que desees actualizar

            _aplicacionContexto.SaveChanges();
            return Ok(existingUniversidad);
        }

        // Delete: Eliminar una universidad por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var universidad = _aplicacionContexto.Universidades.FirstOrDefault(u => u.IdUniversidad == id);

            if (universidad == null)
            {
                return NotFound();
            }

            _aplicacionContexto.Universidades.Remove(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(id);
        }
    }

}
