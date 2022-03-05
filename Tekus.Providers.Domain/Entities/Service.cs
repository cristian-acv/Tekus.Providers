using Tekus.Providers.Domain.Common;

namespace Tekus.Providers.Domain.Entities
{
    public class Service : BaseDomainModel
    { 

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double ValuePerHour { get; set; }

        public virtual ICollection<ProviderService> ProvidersServices { get; set; } = new List<ProviderService>();
    }
}
