namespace ECommerce.UI.Areas.Admin.MVVM
{
    public class BaseVM
    {
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccedMessage { get; set; } = string.Empty;
        public bool IsSucced { get; set; }
    }
}
