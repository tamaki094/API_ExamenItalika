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

        public bool BorrarAlumno(Alumno alumno)
        {
            _context.Remove(alumno);
            var afectados = _context.SaveChanges();
            return afectados > 0;
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

        public Alumno GetAlumnoById(int idAlumno)
        {
            return _context.Alumnos.Where(w => w.IdAlumno == idAlumno).First();
        }

        public List<Alumno> GetAlumnos()
        {
            return _context.Alumnos.ToList();
        }
    }
}
