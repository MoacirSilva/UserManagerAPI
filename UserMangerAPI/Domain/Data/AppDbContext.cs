using Microsoft.EntityFrameworkCore;
using UserManagerAPI.Domain.Entities;

namespace UserManagerAPI.Domain.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<GrupoUsuario> grupoUsuarios { get; set; }
    }
}
