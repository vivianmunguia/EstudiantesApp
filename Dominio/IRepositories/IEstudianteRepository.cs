using EstudiantesApp.Transporte;
using System.Threading.Tasks;

namespace EstudiantesApp.Dominio.IRepositories
{
    public interface IEstudianteRepository
    {
        Task<List<EstudianteDTO>> ConsultaEstudiantes();
        Task<bool> CrearEstudiante(EstudianteDTO estudiante);
        Task<EstudianteDTO> ConsultaEstudiante(int id);
        Task<bool> EditarEstudiante(EstudianteDTO estudiante);
        Task<bool> EliminarEstudiante(int id);
    }
}
