using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Application.Exceptions;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Services.Commands.UpdateService
{

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateServiceCommandHandler> _logger;

        public UpdateServiceCommandHandler(ApplicationDbContext context,
            IMapper mapper,
        ILogger<UpdateServiceCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Services
           .Where(l => l.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                _logger.LogError($"{request.Id} service does not exist in the system");
                throw new NotFoundException(nameof(Service), request.Id);
            }

            entity = _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"The operation was successful updating the provider {request.Id}");

            return Unit.Value;

        }
    }
}
