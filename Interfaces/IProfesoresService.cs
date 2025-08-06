using API_Cursos.Models;

namespace API_Cursos.Interfaces
{
    public interface IProfesoresService
    {
        List<Profesor> GetProfesores();
        bool CrearProfesor(Profesor profesor);
    }
}
