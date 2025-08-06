using API_Cursos.Data;
using API_Cursos.Interfaces;
using API_Cursos.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Cursos.Services
{
    public class AlumnosService : IAlumnosService
    {
        private readonly EscuelaContext _context;

        public AlumnosService(EscuelaContext context)
        {
            _context = context;
        }

        public bool BorrarAlumno()
        {
            throw new NotImplementedException();
        }

        public bool CrearAlumno(Alumno alumno)
        {
            var result = _context.ResultadoSPs.FromSqlInterpolated($@"
                EXEC NuevoAlumno 
                    @Nombre = {alumno.Nombre}, 
                    @ApellidoPaterno = {alumno.ApellidoPaterno}, 
                    @ApellidoMaterno = {alumno.ApellidoMaterno}, 
                    @FechaNacimiento = {alumno.FechaNacimiento}
            ")
                .AsEnumerable().FirstOrDefault();

            return (result.Estado == "insertado" || result.Estado == "actualizado") ? true : false;
        }

        public List<Alumno> GetAlumnos()
        {
            return _context.Alumnos.ToList();
        }
    }
}
