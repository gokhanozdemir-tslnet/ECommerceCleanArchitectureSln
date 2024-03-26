using ECommerce.Core.Domain.Entities;
using ECommerce.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ECommerce.UI.Components.Common
{
    public class Dropdown:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DropdownCompViewModel model)
        {
            
            return View("~/Views/Shared/Components/Common/Dropdown.cshtml", model);
        }
    }
}
