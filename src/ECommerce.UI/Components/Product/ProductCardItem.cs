using ECommerce.Core.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Components.Product
{
    public class ProductCardItem: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(GetProductResponse product)
        {
            return View("~/Views/Shared/Components/Product/ProductCardItem.cshtml",product);
        }
    }
}
