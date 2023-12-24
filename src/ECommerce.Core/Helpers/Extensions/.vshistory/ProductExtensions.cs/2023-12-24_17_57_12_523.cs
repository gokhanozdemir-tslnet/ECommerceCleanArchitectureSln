
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;

namespace ECommerce.Core.Helpers.Extensions
{
    public static class ProductExtensions
    {
        public static GetProductResponse ToGetProductResponse(this Product product)
        {
            GetProductResponse response = AppMapperBase
              .Mapper
              .Map<GetProductResponse>(product);
            return response;
        }
        public static Product ToProduct(this AddProductRequest reqproduct)
        {
            Product product = AppMapperBase
            .Mapper
            .Map<Product>(reqproduct);
            return product;
        }
    }
}
