using API_Cursos.Models;

namespace API_Cursos.Interfaces
{
    public interface ICursosService
    {
        bool CrearCurso(Curso curso);
        List<Curso> GetCursos();
    }
}
