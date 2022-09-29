using API_invvideojuegos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API_invvideojuegos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<videojuegos> Videojuegos { get; set; }
        public DbSet<Juegos> Juego { get; set; }
    }
}
