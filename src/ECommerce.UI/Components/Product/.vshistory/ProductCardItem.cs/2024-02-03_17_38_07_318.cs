using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Components.Product
{
    public class ProductCardItem: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
