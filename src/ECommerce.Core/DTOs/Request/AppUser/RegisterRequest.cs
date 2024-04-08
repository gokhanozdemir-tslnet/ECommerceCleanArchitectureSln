

using ECommerce.Core.Enums;

namespace ECommerce.Core.DTOs.Request.AppUser
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get;set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } 
        public string Adress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public AppUserTypeOptions UserType { get; set; } = AppUserTypeOptions.User; 
     

    }
}
