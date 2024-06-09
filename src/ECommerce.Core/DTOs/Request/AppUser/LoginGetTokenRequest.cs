
namespace ECommerce.Core.DTOs.Request.AppUser
{
    public class LoginGetTokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;        
    }
}
