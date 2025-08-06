using API_Cursos.Models;

namespace API_Cursos.Interfaces
{
    public interface IAlumnosService
    {
        List<Alumno> GetAlumnos();
        bool CrearAlumno(Alumno alumno);
        bool BorrarAlumno();
    }
}
