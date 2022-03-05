using MediatR;

namespace Tekus.Providers.Application.Features.Services.Commands.DeleteService
{
   
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
