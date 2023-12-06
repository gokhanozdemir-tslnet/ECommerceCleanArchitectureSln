
using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.DTOs.Response
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;
        public int Rate { get; set; }
        public int Stock { get; set; }
        public List<ProductDetail>? Details { get; set; }
        public Category Category { get; set; }
    }
}
