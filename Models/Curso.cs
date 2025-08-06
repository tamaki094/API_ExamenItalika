using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Cursos.Models
{
    public class Curso
    {
        [Key]
        [JsonIgnore]
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
        [JsonIgnore]
        public DateTime? FechaModificacion { get; set; }

        public int IdProfesor { get; set; }

        [ForeignKey("IdProfesor")]
        [JsonIgnore]
        public Profesor? Profesor { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
