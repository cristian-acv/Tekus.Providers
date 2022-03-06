using Tekus.Providers.Application.Features.Services.Queries.GetServicesList;
using Tekus.Providers.Domain.Entities;

namespace Tekus.Providers.Application.Features.Providers.Queries.GetProviders
{
    public class ProviderVm
    {
        public string NIT { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public virtual ICollection<ServicesVm> ProvidersServices { get; set; } = new List<ServicesVm>();
    }
}
