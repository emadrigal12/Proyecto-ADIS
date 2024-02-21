namespace ProyectoADIS.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public string Contrasena { get; set; }
        public string CambioContrasena { get; set; }
        public bool Estado { get; set; }
    }
}
