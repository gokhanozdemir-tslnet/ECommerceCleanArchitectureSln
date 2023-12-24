using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.ProductContracts
{
    public interface IProductGetterService
    {

        GetProductResponse GetProduct(GetProductRequest request);
        async Task<List<Product>> GetAllProducts()
    }
}
