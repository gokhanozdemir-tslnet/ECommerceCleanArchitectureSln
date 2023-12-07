
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;
using ECommerce.Core.ServiceContracts;

namespace ECommerce.Core.Services
{
    public class ProductService : IProductService
    {
        public AddProductResponse AddProduct(AddProductRequest request)
        {
            //Check if AddProductRequest is null
            //Validate properties
            //Generate ProductId
            //Add Product
            //response


            throw new NotImplementedException();
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            

            if (request == null)
                throw new ArgumentNullException(nameof(request));
            throw new NotImplementedException();

            Product product = new Product { Id=1,Title="Phone" ,Price=10M};
            //Reposiorty get product
            GetProductResponse response = AppMapperBase.Mapper.Map<GetProductResponse>(product);
            return response;

        }
    }
}
