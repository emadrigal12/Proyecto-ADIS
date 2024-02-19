using Microsoft.EntityFrameworkCore;
using ProyectoADIS.Entities;

namespace ProyectoADIS
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}
