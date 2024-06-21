using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.Domain.RepositoryContracts.Auth;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.DTOs.Response.AppUser;
using ECommerce.WebAPI.Auth.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace ECommerce.WebAPI.Auth.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;


        public TokenController(IAuthService authService, SignInManager<AppUser> signInManager)
        {
                _tokenService = authService;
                _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<ApiResponse<AuthenticationResponse>> GetToken([FromHeader] string email, [FromHeader] string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false,lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                this.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return ApiResponse<AuthenticationResponse>.Fail("Invalid username or password");
            }
            string Issuer = "http://localhost:4200";
            string Audience = "http://localhost:4200";
            string Key = "this is secret key for jwt dfsdfgfhf fghhgjghjgh";
            string EXPIRATION_MINUTES = "5";


            Console.WriteLine("User Id: " + User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine("Username: " + User.FindFirstValue(ClaimTypes.Name));
            Console.WriteLine("Role: " + User.FindFirstValue(ClaimTypes.Role));
            Console.WriteLine("First name: " + User.FindFirstValue("firstname"));
            Console.WriteLine("Last name: " + User.FindFirstValue("lastname"));

            LoginRequest loginRequest = new LoginRequest
            {
                Email = "TEST@MAİL.COM",
                Password = "password",
            };

            var TOKEN = await _tokenService.GenerateJWTToken("1", email, "personname", EXPIRATION_MINUTES, Key, Issuer, Audience, "2500");

            return ApiResponse<AuthenticationResponse>.Success(TOKEN);
        }
    }
}
