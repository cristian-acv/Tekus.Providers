using MediatR;

namespace Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommand :  IRequest 
    {
        public int Id { get; set; }

        public string NIT { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<int> Services { get; set; } = new List<int>();
    }
}
