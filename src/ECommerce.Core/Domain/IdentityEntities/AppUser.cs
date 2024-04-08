
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Domain.IdentityEntities
{
    public class AppUser : IdentityUser<Guid>    {
        
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;  
        public string PostalCode { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

    }
}
