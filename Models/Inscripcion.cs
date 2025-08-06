using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Cursos.Models
{
    public class Inscripcion
    {
        [Key]
        [JsonIgnore]
        public int IdInscripcion { get; set; }
        [JsonIgnore]
        public DateTime FechaInscripcion { get; set; }

        public int IdAlumno { get; set; }

        [ForeignKey("IdAlumno")]
        [JsonIgnore]
        public Alumno? Alumno { get; set; } = null!;

        public int IdCurso { get; set; }
        
        [ForeignKey("IdCurso")]
        [JsonIgnore]
        public Curso? Curso { get; set; } = null!;
    }
}
