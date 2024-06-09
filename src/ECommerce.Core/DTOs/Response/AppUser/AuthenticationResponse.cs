
using System;

namespace ECommerce.Core.DTOs.Response.AppUser
{
    public class AuthenticationResponse
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public string PersonName { get; internal set; }
        public DateTime RefreshTokenExpirationDateTime { get; internal set; }
    }
}
