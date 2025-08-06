using API_Cursos.Models;

namespace API_Cursos.Interfaces
{
    public interface IInscripcionesService
    {
        List<Inscripcion> GetInscripciones();
        bool InscribirAlumno(Inscripcion inscripcion); 
    }
}
