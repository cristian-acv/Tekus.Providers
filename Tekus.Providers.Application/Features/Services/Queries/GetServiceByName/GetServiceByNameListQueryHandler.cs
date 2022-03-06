using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Services.Queries.GetServicesList
{
    public class GetServiceByNameListQueryHandler : IRequestHandler<GetServiceByNameListQuery, List<ServicesVm>>
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetServiceByNameListQueryHandler> _logger;

        public GetServiceByNameListQueryHandler(ApplicationDbContext context,
            IMapper mapper,
        ILogger<GetServiceByNameListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ServicesVm>> Handle(GetServiceByNameListQuery request, CancellationToken cancellationToken)
        {
            var servicesList = await _context.Services.Where(s => s.Name == request._Name).ToListAsync();

            _logger.LogInformation("The query was successful");

            return _mapper.Map<List<ServicesVm>>(servicesList);
        }

    }
}
