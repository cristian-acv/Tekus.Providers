using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Providers.Domain.Entities;

namespace Tekus.Providers.Infrastructure.Persistence.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
           
            builder.Property(t => t.NIT)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(t => t.Description)
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(t => t.Email)
             .IsRequired();
        }
    }
}
