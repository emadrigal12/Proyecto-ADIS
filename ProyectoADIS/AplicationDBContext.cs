using Microsoft.EntityFrameworkCore;
using ProyectoADIS.Entities;
using ProyectoADIS.Models;

namespace ProyectoADIS
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Asignacion> Asignacion { get; set; }
    }
}
