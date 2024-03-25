using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.UI.Models
{
    public class DropdownCompViewModel
    {
        public string AspFor { get; set; }
        public List<SelectListItem> List { get; set; }
    }
}
