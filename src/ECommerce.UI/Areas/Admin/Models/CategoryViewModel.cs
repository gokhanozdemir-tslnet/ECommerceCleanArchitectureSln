namespace ECommerce.UI.Areas.Admin.Models
{
    public class CategoryViewModel<T>
    {
        public bool IsSucced { get; set; }
        public string SuccedMessage { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public T Data { get; set; }
    }
}
