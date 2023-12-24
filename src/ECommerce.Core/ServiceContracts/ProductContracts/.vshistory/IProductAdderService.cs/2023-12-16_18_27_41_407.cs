
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.ProductContracts
{
    public interface IProductAdderService
    {
        Task<AddProductResponse> AddProduct(AddProductRequest request);
    }
}