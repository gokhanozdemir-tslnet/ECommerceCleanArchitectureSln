

using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.ProductContracts
{
    internal interface IProductGetterService
    {

        GetProductResponse GetProduct(GetProductRequest request);
    }
}
