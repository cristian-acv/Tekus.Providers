namespace Tekus.Providers.Application.Features.Services.Queries.GetServicesList
{
    public class ServicesVm
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double ValuePerHour { get; set; }

        public string Country { get; set; } = string.Empty;
    }
}
