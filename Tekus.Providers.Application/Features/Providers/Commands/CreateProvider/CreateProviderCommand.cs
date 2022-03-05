using MediatR;

namespace Tekus.Providers.Application.Features.Providers.Commands.CreateProvider
{
    public class CreateProviderCommand : IRequest<int>
    {
        public string NIT { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<int> Services { get; set; } = new List<int>();

    }
}
