using EstudiantesApp.Transporte;

namespace EstudiantesApp.Dominio.IServices
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDTO>> ConsultaEstudiantes();
        Task<bool> CrearEstudiante(EstudianteDTO estudiante);
        Task<EstudianteDTO> ConsultaEstudiante(int id);
        Task<bool> EditarEstudiante(EstudianteDTO estudiante);
        Task<bool> EliminarEstudiante(int id);
    }
}
