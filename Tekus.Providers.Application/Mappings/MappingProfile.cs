using AutoMapper;
using Tekus.Providers.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider;
using Tekus.Providers.Application.Features.Services.Commands.CreateService;
using Tekus.Providers.Application.Features.Services.Commands.UpdateService;
using Tekus.Providers.Domain.Entities;

namespace Tekus.Providers.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProviderCommand, Provider>()
                .ForMember(provider => provider.ProvidersServices, options => options.MapFrom(MapProviderServices));
            CreateMap<UpdateProviderCommand, Provider>();

            CreateMap<CreateServiceCommand, Service>();
            CreateMap<UpdateServiceCommand, Service>();
       
        }

        private List<ProviderService> MapProviderServices(CreateProviderCommand createProviderCommand, Provider provider)
        {
            var result = new List<ProviderService>();

            if(createProviderCommand.Services == null)
            {
                return result;
            }


            foreach (var serviceId in createProviderCommand.Services)
            {
                result.Add(new ProviderService() { ServiceId = serviceId });
            }

            return result;
        }
    }
}
