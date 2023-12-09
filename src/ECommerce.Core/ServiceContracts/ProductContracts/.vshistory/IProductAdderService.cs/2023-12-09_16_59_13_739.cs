
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.ProductContracts
{
    internal interface IProductAdderService
    {
        AddProductResponse AddProduct(AddProductRequest request);
    }
}