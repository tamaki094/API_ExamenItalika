using API_Cursos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cursos.Data
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext(DbContextOptions<EscuelaContext> options)
            : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<ResultadoSP> ResultadoSPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Inscripcion>()
                .HasIndex(i => new { i.IdAlumno, i.IdCurso })
                .IsUnique();


            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Profesor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(c => c.IdProfesor);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Alumno)
                .WithMany(a => a.Inscripciones)
                .HasForeignKey(i => i.IdAlumno);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Curso)
                .WithMany(c => c.Inscripciones)
                .HasForeignKey(i => i.IdCurso);

            modelBuilder.Entity<ResultadoSP>().HasNoKey();

        }
    }
}
