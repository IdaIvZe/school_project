using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
// Sustituye "School.Api.Models" por el namespace real de tus modelos
using School.Domain.Entities; 

namespace School.Infrastructure.Persistence.Data
{
    public class RemoteDbContext : DbContext
    {
        public RemoteDbContext(DbContextOptions<RemoteDbContext> options)
            : base(options)
        {
        }

        // Aquí registra tabla de usuarios
        public DbSet<Persona> Usuarios { get; set; }
    }

    public class DbConnectionFactory : IDesignTimeDbContextFactory<RemoteDbContext>
    {
        public RemoteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RemoteDbContext>();
            // Usamos la cadena que me pasaste
            optionsBuilder.UseNpgsql("Host=db.uodbkwhehesbpwdgbejd.supabase.co;Database=postgres;Username=postgres;Password=gl%8#bm/KUACy4C;SSL Mode=Require;Trust Server Certificate=true");

            return new RemoteDbContext(optionsBuilder.Options);
        }
    }
}