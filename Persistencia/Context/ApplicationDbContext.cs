
using EstudiantesApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApp.Persistencia.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
