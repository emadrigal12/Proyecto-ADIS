using ProyectoADIS.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoADIS.Models
{
    public class CursoRubro
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Descripcion { get; set; }

        public int Valor { get; set; }

        public int CursoId { get; set; }

        public Cursos Curso { get; set; }
    }
}
