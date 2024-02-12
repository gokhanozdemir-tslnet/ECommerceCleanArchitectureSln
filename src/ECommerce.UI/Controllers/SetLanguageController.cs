using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class SetLanguageController : Controller
    {
        [HttpPost]
        public IActionResult Chance(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
