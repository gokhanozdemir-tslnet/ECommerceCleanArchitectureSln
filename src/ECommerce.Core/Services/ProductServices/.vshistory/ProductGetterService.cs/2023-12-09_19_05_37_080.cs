
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using FluentValidation;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        ProductGetterValidator _validator;

        public ProductGetterService()
        {
            _validator = new ProductGetterValidator();
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
     
            _validator.ValidateAndThrow(request);


            //if (request == null)
            //    throw new ArgumentNullException(nameof(request));


            Product product = new Product { Id = 1, Title = "Phone", Price = 10M };
            //Reposiorty get product
            GetProductResponse response = AppMapperBase.Mapper.Map<GetProductResponse>(product);
            return response;
        }
    }
}
