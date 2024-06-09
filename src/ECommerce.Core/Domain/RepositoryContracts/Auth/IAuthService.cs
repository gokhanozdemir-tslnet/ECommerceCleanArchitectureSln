
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.DTOs.Response.AppUser;

namespace ECommerce.Core.Domain.RepositoryContracts.Auth
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> GenerateJWTToken(string userId, string email, string personname, string EXPIRATION_MINUTES, string key
            , string Issuer, string Audience, string refreshTokenEXPIRATION_MINUTES
            );
    }
}
