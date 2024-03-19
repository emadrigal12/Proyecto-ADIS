using ProyectoADIS.Entities;

namespace ProyectoADIS.Models
{
    public class Curso_Asistencia
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int CursoId { get; set; }

        public Cursos Curso { get; set; }


    }
}
