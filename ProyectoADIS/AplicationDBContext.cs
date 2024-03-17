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
        public AplicationDBContext(string valor) => Valor = valor;
        public string Valor { get; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Asignacion> Asignacion { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<CursoRubro> CursosRubro { get; set; }
        public DbSet<CursoAsistencia> CursoAsistencia { get; set; }
    }
}
