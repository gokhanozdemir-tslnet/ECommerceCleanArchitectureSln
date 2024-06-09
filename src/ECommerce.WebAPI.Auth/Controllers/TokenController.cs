using ECommerce.Core.Domain.RepositoryContracts.Auth;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.DTOs.Response.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Auth.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        IAuthService _tokenService;

        public TokenController(IAuthService authService)
        {
                _tokenService = authService;
        }

        public async Task<AuthenticationResponse> GetToken(LoginRequest reg)
        {
            string Issuer = "http://localhost:4200";
            string Audience = "http://localhost:4200";
            string Key = "this is secret key for jwt dfsdfgfhf fghhgjghjgh";
            string EXPIRATION_MINUTES = "5";

            LoginRequest loginRequest = new LoginRequest
            {
                Email = "TEST@MAİL.COM",
                Password= "password",
            };

            var TOKEN = await _tokenService.GenerateJWTToken("1", loginRequest.Email, "personname", EXPIRATION_MINUTES, Key, Issuer, Audience, "2500");
            return TOKEN;
        }
    }
}
