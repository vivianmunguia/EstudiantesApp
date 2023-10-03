using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.IServices;
using EstudiantesApp.Transporte;

namespace EstudiantesApp.Servicios.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _IEstudianteRepository;

        public EstudianteService(IEstudianteRepository iEstudianteRepository)
        {
            _IEstudianteRepository = iEstudianteRepository;
        }

        public async Task<EstudianteDTO> ConsultaEstudiante(int id)
        {
            return await _IEstudianteRepository.ConsultaEstudiante(id);
        }

        public async Task<List<EstudianteDTO>> ConsultaEstudiantes()
        {
            return await _IEstudianteRepository.ConsultaEstudiantes();
        }

        public async Task<bool> CrearEstudiante(EstudianteDTO estudiante)
        {
            return await _IEstudianteRepository.CrearEstudiante(estudiante);
        }

        public async Task<bool> EditarEstudiante(EstudianteDTO estudiante)
        {
            return await _IEstudianteRepository.EditarEstudiante(estudiante);
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            return await _IEstudianteRepository.EliminarEstudiante(id);
        }
    }
}
