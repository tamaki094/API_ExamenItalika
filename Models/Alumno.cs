using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Cursos.Models
{
    public class Alumno
    {
        [Key]
        [JsonIgnore]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }

        [JsonIgnore]
        public DateTime? FechaModificacion { get; set; }

        [JsonIgnore]
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
