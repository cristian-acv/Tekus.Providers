namespace Tekus.Providers.Domain.Entities
{
    public class ProviderService 
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public virtual Provider? Provider { get; set; }

        public int ServiceId { get; set; }

        public virtual Service? Service { get; set; } 
    }
}
