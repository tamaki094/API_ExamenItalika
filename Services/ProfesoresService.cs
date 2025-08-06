using API_Cursos.Data;
using API_Cursos.Interfaces;
using API_Cursos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cursos.Services
{
    public class ProfesoresService : IProfesoresService
    {
        private readonly EscuelaContext _context;

        public ProfesoresService(EscuelaContext context)
        {
            _context = context;
        }

        public List<Profesor> GetProfesores()
        {
            return _context.Profesores.ToList();
        }

        public bool CrearProfesor(Profesor profesor)
        {
            var result = _context.ResultadoSPs.FromSqlInterpolated($@"
                EXEC NuevoProfesor 
                    @Nombre = {profesor.Nombre}, 
                    @ApellidoPaterno = {profesor.ApellidoPaterno}, 
                    @ApellidoMaterno = {profesor.ApellidoMaterno}, 
                    @FechaNacimiento = {profesor.FechaNacimiento}
            ")
            .AsEnumerable().FirstOrDefault();

            return (result.Estado == "insertado" || result.Estado == "actualizado") ? true : false;
        }
    }
}
