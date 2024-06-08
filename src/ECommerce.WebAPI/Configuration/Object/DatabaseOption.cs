namespace ECommerce.WebAPI.Configuration.Object
{
    public class DatabaseOption
    {
        public const string SectionName = "Database";
        public string ECommerceDb { get; set; }=string.Empty;
        public string IdentityConnection { get; set; } = string.Empty;

    }
}
