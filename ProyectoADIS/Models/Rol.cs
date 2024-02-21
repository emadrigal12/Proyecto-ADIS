using System.ComponentModel.DataAnnotations;

namespace ProyectoADIS.Entities
{
    public class Rol
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength:50, ErrorMessage ="El campo {0} debe tener menos de {1} caracteres")]
        public string Descripcion { get; set; }


    }
}
