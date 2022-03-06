using MediatR;

namespace Tekus.Providers.Application.Features.Providers.Queries.GetProviders
{
    public class GetProvidersQuery : IRequest<PaginatedList<ProviderVm>>
    {
        public string Search { get; set; } = string.Empty;

        public string Orden { get; set; } = string.Empty;

        public string OrdenType { get; set; } = string.Empty;

        public int Pagination { get; set; } = 1;

        public int PageSize { get; set; } = 10;


    }
}
