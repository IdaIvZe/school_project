using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using School.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using School.Domain.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace School.Infrastructure.Persistence.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
            // Esto le dice a EF: "Si la tabla no existe, créala ahora mismo"
            this.Database.EnsureCreated();
        }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocalDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {

                if (entry.Entity is Persona persona)
                {
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        persona.SyncStatus = SyncStatus.Pending;
                    }
                }

            }

            return await base.SaveChangesAsync(cancellationToken);

            }
        }
    }
