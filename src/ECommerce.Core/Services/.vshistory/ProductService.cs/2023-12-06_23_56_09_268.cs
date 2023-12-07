
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.ServiceContracts;

namespace ECommerce.Core.Services
{
    public class ProductService : IProductService
    {
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            throw new NotImplementedException();
        }
    }
}
