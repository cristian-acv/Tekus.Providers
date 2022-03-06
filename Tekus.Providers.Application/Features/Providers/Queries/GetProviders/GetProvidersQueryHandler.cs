using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Tekus.Providers.Domain.Entities;
using Tekus.Providers.Infrastructure.Persistence;

namespace Tekus.Providers.Application.Features.Providers.Queries.GetProviders
{
    public class GetProvidersQueryHandler : IRequestHandler<GetProvidersQuery, PaginatedList<ProviderVm>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProvidersQueryHandler> _logger;

        public GetProvidersQueryHandler(ApplicationDbContext context,
            IMapper mapper,
            ILogger<GetProvidersQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedList<ProviderVm>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
        {
            List<Provider> providers;
            PaginatedList<ProviderVm> paginatedListProviders;

           
            providers = await _context.Providers
                .Include(provider => provider.ProvidersServices)
                .ThenInclude(service => service.Service)
                 .AsNoTracking()
                 .ToListAsync();

            if (!string.IsNullOrEmpty(request.Search))
            {
                foreach (var item in request.Search.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    providers = providers.Where(x => x.NIT.Contains(item) ||
                                                  x.Name.Contains(item) ||
                                                  x.Email.Contains(item))
                                                  .ToList();
                }
            }

            switch (request.Orden)
            {
                case "NIT":
                    if (request.OrdenType.ToLower() == "desc")
                        providers = providers.OrderByDescending(x => x.NIT).ToList();
                    else if (request.OrdenType.ToLower() == "asc")
                        providers = providers.OrderBy(x => x.NIT).ToList();
                    break;

                case "Name":
                    if (request.OrdenType.ToLower() == "desc")
                        providers = providers.OrderByDescending(x => x.Name).ToList();
                    else if (request.OrdenType.ToLower() == "asc")
                        providers = providers.OrderBy(x => x.Name).ToList();
                    break;

                case "Email":
                    if (request.OrdenType.ToLower() == "desc")
                        providers = providers.OrderByDescending(x => x.Email).ToList();
                    else if (request.OrdenType.ToLower() == "asc")
                        providers = providers.OrderBy(x => x.Email).ToList();
                    break;


                default:
                    if (request.OrdenType.ToLower() == "desc")
                        providers = providers.OrderByDescending(x => x.Name).ToList();
                    else if (request.OrdenType.ToLower() == "asc")
                        providers = providers.OrderBy(x => x.Name).ToList();
                    break;
            }

            int _TotalRecords = 0;
            int _TotalPages = 0;

            _TotalRecords = providers.Count();
        
            providers = providers.Skip((request.Pagination - 1) * request.PageSize)
                                             .Take(request.PageSize)
                                             .ToList();
           
            _TotalPages = (int)Math.Ceiling((double)_TotalRecords / request.PageSize);


            List<ProviderVm> providerVms = _mapper.Map<List<ProviderVm>>(providers);


            paginatedListProviders = new PaginatedList<ProviderVm>()
            {
                RecordsPerPage = request.PageSize,
                TotalRecords = _TotalRecords,
                TotalPages = _TotalPages,
                ActualPage = request.Pagination,
                CurrentSearch = request.Search,
                CurrentOrderType = request.OrdenType,
                Result = providerVms
            };

            _logger.LogInformation($"The query was carried out correctly");

            return paginatedListProviders;
        }
    }
}
