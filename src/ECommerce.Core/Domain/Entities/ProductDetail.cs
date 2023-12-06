
namespace ECommerce.Core.Domain.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ProductId { get; set; }

    }
}
