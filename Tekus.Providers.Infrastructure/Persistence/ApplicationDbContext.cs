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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   

        }

        public DbSet<Provider> Providers => Set<Provider>();

        public DbSet<Service> Services  => Set<Service>();

        public DbSet<ProviderService> ProvidersServices => Set<ProviderService>();
    }
}
