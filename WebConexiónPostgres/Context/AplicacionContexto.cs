using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ModelsProfessor;
using WebApplication2.ModelsUniversities;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<University> University { get; set; }
    }
}
