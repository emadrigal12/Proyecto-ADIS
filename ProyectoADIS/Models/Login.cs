using ProyectoADIS.Entities;

namespace ProyectoADIS.Models
{
    public class Login
    {

        public string Usuario { get; set; }
        public string? Password { get; set; }
        public string? newPassword { get; set; }
        public string? actualPassword { get; set; }

        
    }
}
