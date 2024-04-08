using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.Enums;
using ECommerce.Core.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, 
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest user)
        {

            AppUser appUser = user.ToAppUser();
            appUser.UserName = user.Email;
            IdentityResult result = await _userManager.CreateAsync(appUser,user.Password);
            if (result.Succeeded)
            {
                if (await _roleManager.FindByNameAsync(AppUserTypeOptions.User.ToString()) is null)
                {
                    AppRole appRole = new AppRole
                    {
                        Name = AppUserTypeOptions.User.ToString(),
                    };
                    await _roleManager.CreateAsync(appRole);
                }

               _=await _userManager.AddToRoleAsync(appUser,AppUserTypeOptions.User.ToString());

                await _signInManager.SignInAsync(appUser, isPersistent: true);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
            }

            return View(user);
        }
    }
}
