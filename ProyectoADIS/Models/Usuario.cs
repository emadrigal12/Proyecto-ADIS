using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoADIS.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Correo { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Apellido1 { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Apellido2 { get; set; }

        public int RolId { get; set; }

        public Rol Rol { get; set; }

        [Column(TypeName = "varchar(18)")]

        public string Contrasena { get; set; }

        [Column(TypeName = "varchar(1)")]
        [DefaultValue("S")]
        public string CambioContrasena { get; set; }
    }
}
