using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Application.Exceptions;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Services.Commands.DeleteService
{

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DeleteServiceCommandHandler> _logger;

        public DeleteServiceCommandHandler(ApplicationDbContext context,
            ILogger<DeleteServiceCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Services
           .Where(l => l.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                _logger.LogError($"{request.Id} service does not exist in the system");
                throw new NotFoundException(nameof(Service), request.Id);
            }

            _context.Services.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"The {request.Id} service was successfully eliminated");

            return Unit.Value;
        }
    }
}
