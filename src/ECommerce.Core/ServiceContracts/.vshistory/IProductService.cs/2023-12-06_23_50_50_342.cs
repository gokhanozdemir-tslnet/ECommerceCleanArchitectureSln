
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest? request);

    }
}
