using Tekus.Providers.Domain.Common;

namespace Tekus.Providers.Domain.Entities
{
    public class Provider : BaseDomainModel
    {

        public string NIT { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public virtual ICollection<ProviderService> ProvidersServices { get; set; } = new List<ProviderService>();
    }
}
