using Microsoft.EntityFrameworkCore;
using BDuniversidad.models;


namespace BDuniversidad.context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docente>()
                .HasOne(d => d.Universidad)
                .WithMany()
                .HasForeignKey(d => d.IdUniversidad);

            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Universidad)
                .WithMany()
                .HasForeignKey(e => e.IdUniversidad);
        }
    }

}
