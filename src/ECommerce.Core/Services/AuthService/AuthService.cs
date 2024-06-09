
using ECommerce.Core.Domain.RepositoryContracts.Auth;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.DTOs.Response.AppUser;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Core.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
        }

        public async Task<AuthenticationResponse> GenerateJWTToken(string userId,string email,string personname, string EXPIRATION_MINUTES, string key
            , string Issuer, string Audience,string refreshTokenEXPIRATION_MINUTES
            )
        {
            string token = "";
            //_configuration["Jwt:EXPIRATION_MINUTES"]
            //user.Id
            //_configuration["Jwt:Key"]
            //_configuration["Jwt:Issuer"]
            //_configuration["Jwt:Audience"]
            //_configuration["RefreshToken:EXPIRATION_MINUTES"]
            try
            {
                DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(EXPIRATION_MINUTES));



                Claim[] claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub,userId), //Subject for user id
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),//ensures to create unique JWt token, unique param
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),//time for th jwt 
                new Claim(ClaimTypes.NameIdentifier,email),
                new Claim(ClaimTypes.Name,personname),

            };


                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken tokenGenerator = new JwtSecurityToken(
                    Issuer,
                    Audience,
                    expires: expiration,
                    signingCredentials: signingCredentials

                    );


                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                token = tokenHandler.WriteToken(tokenGenerator);
                string refreshToken = GenerateRefreshToken();
                DateTime refreshTokenExpirationDateTime = DateTime.Now.AddMinutes(
                        Convert.ToInt32(refreshTokenEXPIRATION_MINUTES)
                    );

                return new AuthenticationResponse
                {
                    AccessToken = token,
                    Email = email,
                    Expiration = expiration,
                    PersonName = personname,
                    RefreshToken = refreshToken,
                    RefreshTokenExpirationDateTime = refreshTokenExpirationDateTime
                };
            }
            catch (Exception ex)
            {

                throw;
            }         
        }

        public Task<AuthenticationResponse> GenerateJWTToken(LoginRequest req, string expirationMinute, string key, string issuer, string audience)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
