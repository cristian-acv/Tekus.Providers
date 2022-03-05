using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Application.Exceptions;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProviderCommandHandler> _logger;

        public UpdateProviderCommandHandler(ApplicationDbContext context,
            IMapper mapper,
        ILogger<UpdateProviderCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context
                .Providers
                .Include(x => x.ProvidersServices)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                _logger.LogError($"{request.Id} provider does not exist in the system");
                throw new NotFoundException(nameof(Provider), request.Id);
            }

            entity = _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"The operation was successful updating the provider {request.Id}");

            return Unit.Value;

        }
    }
}
