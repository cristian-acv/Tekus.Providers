using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<CreateServiceCommandHandler> _logger;

            public CreateServiceCommandHandler(ApplicationDbContext context,
                IMapper mapper,
                ILogger<CreateServiceCommandHandler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
            {
                
                var entity = _mapper.Map<Service>(request);

                _context.Services.Add(entity);

                var result = await _context.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                {
                    throw new Exception($"Could not insert provider record");
                }

                _logger.LogInformation($"Service {entity.Id} was successfully created");

                return entity.Id;
            }

    }
}
