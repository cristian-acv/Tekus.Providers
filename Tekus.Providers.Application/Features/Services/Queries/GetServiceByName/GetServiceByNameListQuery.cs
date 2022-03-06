using MediatR;

namespace Tekus.Providers.Application.Features.Services.Queries.GetServicesList
{

    public class GetServiceByNameListQuery : IRequest<List<ServicesVm>>
    {
        public string _Name { get; set; } = string.Empty;

        public GetServiceByNameListQuery(string name)
        {
            _Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
