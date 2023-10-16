using BDuniversidad.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext2 = BDuniversidad.context.ApplicationDbContext;
using BDuniversidad.controllers;
//using BDuniversidad.controllers.UniversidadController;

namespace BDuniversidad.Controllers
{
    public class DocenteController
    {
        private readonly ILogger<DocenteController> _logger;
        private readonly ApplicationDbContext2 _aplicacionContexto;

        public DocenteController(
            ILogger<DocenteController> logger,
            ApplicationDbContext2 aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear una universidad
        [HttpPost]
        public IActionResult Post([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad.IdUniversidad);
        }

        // Read: Obtener lista de universidades
        [HttpGet]
        public IEnumerable<Universidad> Get()
        {
            return _aplicacionContexto.Docentes.ToList();
        }

        // Update: Modificar una universidad por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Universidad universidad)
        {
            var existingUniversidad = _aplicacionContexto.Docentes.FirstOrDefault(u => u.IdUniversidad == id);
            if (existingUniversidad == null)
            {
                return NotFound();
            }

            existingUniversidad.Nombre = universidad.Nombre;
            // Agrega otras propiedades que desees actualizar

            _aplicacionContexto.SaveChanges();
            return Ok(existingUniversidad);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        // Delete: Eliminar una universidad por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var universidad = _aplicacionContexto.Docentes.FirstOrDefault(u => u.IdUniversidad == id);

            if (universidad == null)
            {
                return NotFound();
            }

            bool v = _aplicacionContexto.Docente.Remove(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(id);
        }

        private IActionResult Ok(int id)
        {
            throw new NotImplementedException();
        }
    }
}
