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
            optionsBuilder.UseNpgsql("User Id=postgres.uodbkwhehesbpwdgbejd;Password=RusiaM0scu2o3o...;Server=aws-0-us-west-2.pooler.supabase.com;Port=6543;Database=postgres");

            return new RemoteDbContext(optionsBuilder.Options);
        }
    }
}