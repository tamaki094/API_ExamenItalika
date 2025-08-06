using API_Cursos.Data;
using API_Cursos.Interfaces;
using API_Cursos.Models;

namespace API_Cursos.Services
{
    public class InscripcionesService : IInscripcionesService
    {
        private readonly EscuelaContext _context;

        public InscripcionesService(EscuelaContext context)
        {
            _context = context;
        }
        public List<Inscripcion> GetInscripciones()
        {
            return _context.Inscripciones.ToList();
        }

        public bool InscribirAlumno(Inscripcion inscripcion)
        {
            _context.Add(inscripcion);
            var afectados = _context.SaveChanges();
            return afectados > 0;
        }
    }
}
