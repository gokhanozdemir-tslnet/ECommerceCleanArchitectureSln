using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Components
{
    public class Header:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
