using System.ComponentModel.DataAnnotations;

namespace EstudiantesApp.Transporte
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre(s) del alumno")]
        public string Nombres { get; set; }
        [Display(Name = "Apellido(s) del alumno")]
        public string Apellidos { get; set; }
        [Display(Name = "Fecha de inscripción")]
        public string FechaInscripcion { get; set; }
        [Display(Name = "Fecha de inscripción")]
        public DateTime FechaDate { get; internal set; }
    }
}
