using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Providers.Commands.CreateProvider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProviderCommandHandler> _logger;

        public CreateProviderCommandHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<CreateProviderCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var servicesIds = await _context.Services
                .Where(serviceDB => request.Services.Contains(serviceDB.Id)).Select(x => x.Id).ToListAsync();

            if(request.Services.Count != servicesIds.Count)
            {
                throw new Exception($"One of the submitted services does not exist");
            }

            var entity = _mapper.Map<Provider>(request);

            _context.Providers.Add(entity);

            var result = await _context.SaveChangesAsync(cancellationToken);

            if (result <= 0)
            {
                throw new Exception($"Could not insert provider record");
            }

            _logger.LogInformation($"Provider {entity.Id} was successfully created");

            return entity.Id;
        }
    }
}
