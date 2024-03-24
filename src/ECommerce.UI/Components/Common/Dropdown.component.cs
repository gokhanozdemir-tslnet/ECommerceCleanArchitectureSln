using ECommerce.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ECommerce.UI.Components.Common
{
    public class Dropdown:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ModelExpression aspFor = null)
        {
            return View("~/Views/Shared/Components/Common/Dropdown.cshtml", aspFor);
        }
    }
}
