using AutoMapper;
using Tekus.Providers.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider;
using Tekus.Providers.Application.Features.Providers.Queries.GetProviders;
using Tekus.Providers.Application.Features.Services.Commands.CreateService;
using Tekus.Providers.Application.Features.Services.Commands.UpdateService;
using Tekus.Providers.Application.Features.Services.Queries.GetServicesList;
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

            CreateMap<Service, ServicesVm>();

            CreateMap<Provider, ProviderVm>()
                .ForMember(provider => provider.ProvidersServices, act => act.MapFrom(MapServicesList));


               

        }


        #region Mapping
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

        private List<Service> MapServicesList(Provider provider, ProviderVm providerDTO)
        {
            var result = new List<Service>();

            if(provider.ProvidersServices == null)
            {
                return result;
            }

            foreach (var providersServices in provider.ProvidersServices)
            {
                result.Add(new Service()
                {
                    Id = providersServices.Service.Id,
                    Name = providersServices.Service.Name,
                    Description = providersServices.Service.Description,
                    ValuePerHour = providersServices.Service.ValuePerHour,
                    Country = providersServices.Service.Country
                });
            }

            return result;
        }
        #endregion
    }
}
