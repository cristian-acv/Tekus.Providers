using Microsoft.AspNetCore.Identity;

namespace Tekus.Providers.Identity.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public string Surnames { get; set; } = string.Empty;
    }
}
