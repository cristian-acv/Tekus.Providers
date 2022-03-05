using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Application.Exceptions;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Providers.Commands.DeleteProvider
{
    public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DeleteProviderCommandHandler> _logger;

        public DeleteProviderCommandHandler(ApplicationDbContext context,
            ILogger<DeleteProviderCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Providers
           .Where(l => l.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);

            if(entity == null)
            {
                _logger.LogError($"{request.Id} provider does not exist in the system");
                throw new NotFoundException(nameof(Provider), request.Id);
            }

            _context.Providers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"The {request.Id} provider was successfully eliminated");

            return Unit.Value;
        }
    }
}
