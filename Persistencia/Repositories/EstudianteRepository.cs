using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.Models;
using EstudiantesApp.Persistencia.Context;
using EstudiantesApp.Transporte;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApp.Persistencia.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudianteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EstudianteDTO> ConsultaEstudiante(int id)
        {
            var estudiante = await (from t in _context.Estudiante
                                    where t.Id == id
                                    select new EstudianteDTO
                                    {
                                        Id = t.Id,
                                        Nombres = t.Nombres,
                                        Apellidos = t.Apellidos,
                                        FechaInscripcion = t.FechaInscripcion.ToShortDateString(),
                                        FechaDate = t.FechaInscripcion
                                    }).FirstOrDefaultAsync();
            return estudiante;
        }

        public async Task<List<EstudianteDTO>> ConsultaEstudiantes()
        {
            var estudiantes = await (from t in _context.Estudiante
                                     select new EstudianteDTO
                                     {
                                         Id = t.Id,
                                         Nombres = t.Nombres,
                                         Apellidos = t.Apellidos,
                                         FechaInscripcion = t.FechaInscripcion.ToShortDateString()
                                     }).ToListAsync();
            return estudiantes;
        }

        public async Task<bool> CrearEstudiante(EstudianteDTO estudianteFront)
        {
            try
            {
                var fecha = estudianteFront == null ? "" : estudianteFront.FechaInscripcion;
                var esCorrecto = DateTime.TryParse(fecha, out DateTime result);
                if (!esCorrecto) return false;

                var estudiante = new Estudiante
                {
                    FechaInscripcion = result,
                    Nombres = estudianteFront.Nombres,
                    Apellidos = estudianteFront.Apellidos
                };

                _context.Estudiante.Add(estudiante);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditarEstudiante(EstudianteDTO estudianteFront)
        {
            try
            {
                var estudiante = await (from t in _context.Estudiante
                                        where t.Id == estudianteFront.Id
                                        select t).FirstOrDefaultAsync();

                if (estudiante == null) return false;

                var fecha = estudianteFront.FechaInscripcion;
                var esCorrecto = DateTime.TryParse(fecha, out DateTime result);
                if (!esCorrecto) return false;

                estudiante.FechaInscripcion = result;
                estudiante.Nombres = estudianteFront.Nombres;
                estudiante.Apellidos = estudianteFront.Apellidos;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            try
            {
                var estudiante = await (from t in _context.Estudiante
                                        where t.Id == id
                                        select t).FirstOrDefaultAsync();

                if (estudiante == null) return false;

                _context.Estudiante.Remove(estudiante);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
