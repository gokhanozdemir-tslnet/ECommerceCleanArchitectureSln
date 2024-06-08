using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.ProductContracts
{
    public interface IProductGetterService
    {

        Task<GetProductResponse> GetProduct(GetProductRequest request);
        Task<List<GetProductResponse>> GetAllProducts(GetProductsWithPagingRequest request);
        Task<GetProductResponse> GetProductByUId(Guid id);
        Task<List<GetProductResponse>> GetProductsByTitle(string title);
        Task<List<GetProductResponse>> GetProductsByCategoryId(int id);
    }
}
