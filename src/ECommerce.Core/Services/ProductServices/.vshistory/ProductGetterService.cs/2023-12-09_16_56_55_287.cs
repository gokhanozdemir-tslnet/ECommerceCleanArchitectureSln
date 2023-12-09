
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;
using ECommerce.Core.ServiceContracts.ProductContracts;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        public GetProductResponse GetProduct(GetProductRequest request)
        {

            if (request == null)
                throw new ArgumentNullException(nameof(request));


            Product product = new Product { Id = 1, Title = "Phone", Price = 10M };
            //Reposiorty get product
            GetProductResponse response = AppMapperBase.Mapper.Map<GetProductResponse>(product);
            return response;
        }
    }
}
