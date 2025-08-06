using API_Cursos.Data;
using API_Cursos.Interfaces;
using API_Cursos.Models;

namespace API_Cursos.Services
{
    public class CursosService : ICursosService
    {
        private readonly EscuelaContext _context;

        public CursosService(EscuelaContext context)
        {
            _context = context;
        }

        public bool CrearCurso(Curso curso)
        {
            _context.Add(curso);
            var afectados = _context.SaveChanges();

            return afectados > 0;
        }

        public List<Curso> GetCursos()
        {
            return _context.Cursos.ToList();
        }
    }
}
