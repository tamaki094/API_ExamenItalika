using API_Cursos.Interfaces;
using API_Cursos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_Cursos.Controllers
{
    [ApiController]
    [Route("/api/cursos")]
    public class CursosController : ControllerBase
    {
        private readonly IAlumnosService _alumnosService;
        private readonly ICursosService _cursosService;
        private readonly IProfesoresService _profesoresService;
        private readonly IInscripcionesService _incripcionesService;


        public CursosController(IAlumnosService alumnosService, ICursosService cursosService, IProfesoresService profesoresService, IInscripcionesService incripcionesService)
        {
            _alumnosService = alumnosService;
            _cursosService = cursosService;
            _profesoresService = profesoresService;
            _incripcionesService = incripcionesService;
        }

        [HttpGet]
        [Route("alumnos")]
        public async Task<List<Alumno>> GetAlumnos()
        {
            return _alumnosService.GetAlumnos();
        }

        [HttpPost]
        [Route("alumnos")]
        public async Task<dynamic> CrearAlumno(Alumno alumno)
        {
            try
            {
                alumno.FechaCreacion = DateTime.Now;
                var resultado = _alumnosService.CrearAlumno(alumno);

                if (resultado)
                    return Ok(new { mensaje = "Alumno creado o actualizado correctamente." });
                else
                    return BadRequest(new { error = "No se pudo crear el alumno." });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = "Ocurrio un error inesperado.",
                    detalle = ex.Message
                });

            }
        }

        [HttpDelete]
        [Route("alumnos")]
        public async Task<dynamic> BorrarAlumno(int idAlumno)
        {
            try
            {
                Alumno alumno = _alumnosService.GetAlumnoById(idAlumno);
                var resultado = _alumnosService.BorrarAlumno(alumno);

                if (resultado)
                    return Ok(new { mensaje = "Alumno borrado correctamente." });
                else
                    return BadRequest(new { error = "No se pudo borrar el alumno." });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = "Ocurrio un error inesperado.",
                    detalle = ex.Message
                });

            }

        }

        

            [HttpGet]
        [Route("cursos")]
        public async Task<List<Curso>> GetCursos()
        {
            return _cursosService.GetCursos();
        }

        [HttpPost]
        [Route("cursos")]
        public async Task<dynamic> CrearCurso(Curso curso)
        {
            try
            {
                curso.FechaCreacion = DateTime.Now;
                var resultado = _cursosService.CrearCurso(curso);

                if (resultado)
                    return Ok(new { mensaje = "Curso creado o actualizado correctamente." });
                else
                    return BadRequest(new { error = "No se pudo crear el Curso." });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = "Ocurrio un error inesperado.",
                    detalle = ex.Message
                });

            }

        }

        [HttpGet]
        [Route("profesores")]
        public async Task<List<Profesor>> GetProfesores()
        {
            return _profesoresService.GetProfesores();
        }

        [HttpPost]
        [Route("profesores")]
        public async Task<dynamic> CrearProfesor(Profesor profesor)
        {
            try
            {
                profesor.FechaCreacion = DateTime.Now;
                var resultado = _profesoresService.CrearProfesor(profesor);

                if (resultado)
                    return Ok(new { mensaje = "Profesor creado o actualizado correctamente." });
                else
                    return BadRequest(new { error = "No se pudo crear el Profesor." });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = "Ocurrio un error inesperado.",
                    detalle = ex.Message
                });

            }

        }

        [HttpGet]
        [Route("inscripciones")]
        public async Task<List<Inscripcion>> GetInscripciones()
        {
            return _incripcionesService.GetInscripciones();
        }

        [HttpPost]
        [Route("inscripciones")]
        public async Task<dynamic> CrearInscripcion(Inscripcion inscripcion)
        {
            try
            {
                inscripcion.FechaInscripcion = DateTime.Now;

                var resultado = _incripcionesService.InscribirAlumno(inscripcion);

                if (resultado)
                    return Ok(new { mensaje = "Inscripcion creada o actualizada correctamente." });
                else
                    return BadRequest(new { error = "No se pudo crear la Inscripcion." });


            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = "Ocurrio un error inesperado.",
                    detalle = ex.Message
                });

            }

        }



        //[HttpPost]
        //[Route("asignar_curso")]
        //public async Task<dynamic> AsignarCursoProfesor(int profesor, int curso)
        //{
        //    try
        //    {

        //        return Ok(new { mensaje = "OK" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            error = "Ocurrio un error inesperado.",
        //            detalle = ex.Message
        //        });

        //    }

        //}
    }
}
