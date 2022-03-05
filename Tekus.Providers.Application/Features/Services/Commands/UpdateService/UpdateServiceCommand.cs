using MediatR;

namespace Tekus.Providers.Application.Features.Services.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double ValuePerHour { get; set; }

        public string Country { get; set; } = string.Empty;
    }
}
