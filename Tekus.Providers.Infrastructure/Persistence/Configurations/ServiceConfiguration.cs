using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Providers.Domain.Entities;

namespace Tekus.Providers.Infrastructure.Persistence.Configurations
{
    public class ServicerConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {

            builder.Property(t => t.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(t => t.Description)
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(t => t.ValuePerHour)
             .IsRequired();

            builder.Property(t => t.Country)
             .IsRequired()
             .HasMaxLength(100);
        }
    }
}
