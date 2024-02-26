using ProyectoADIS.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProyectoADIS.Models
{
    public class Cursos
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Descripcion { get; set; }

        public DateTime FechaHora_Inicio { get; set; }

        public DateTime FechaHora_Fin { get; set; }

        public int Dia { get; set; }
        public int Requisito { get; set; }

        public int ProfesorId { get; set; }

        public Usuario Profesor { get; set; }

        [Column(TypeName = "varchar(1)")]
        [DefaultValue("S")]
        public string Estado { get; set; }
    }
}
