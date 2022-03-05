using MediatR;

namespace Tekus.Providers.Application.Features.Providers.Commands.DeleteProvider
{
    public class DeleteProviderCommand  : IRequest
    {
        public int Id { get; set; }
    }
}
