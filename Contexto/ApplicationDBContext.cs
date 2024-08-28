using Microsoft.EntityFrameworkCore;
using ProyectoSISINFO3.Entidades;

namespace ProyectoSISINFO3.Contexto
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Centro> Centro { get; set; }
        public DbSet<Matrona> Matrona { get; set; }
        public DbSet<Embarazada> Embarazada { get; set; }
        public DbSet<Clase> Clase { get; set; }
        public DbSet<RegistroClases> RegistroClases { get; set; }
    }
}
