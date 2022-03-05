using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tekus.Providers.Domain.Common;
using Tekus.Providers.Domain.Entities;

namespace Tekus.Providers.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Provider>()
                .HasMany(p => p.Services)
                .WithMany(t => t.Providers)
                .UsingEntity<ProviderService>(
                    pt => pt.HasKey(e => new { e.ProviderId, e.ServiceId })
                );

        }

        public DbSet<Provider> Providers => Set<Provider>();

        public DbSet<Service> Services  => Set<Service>();

        public DbSet<ProviderService> ProvidersServices => Set<ProviderService>();
    }
}
