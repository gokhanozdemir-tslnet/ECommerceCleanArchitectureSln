using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using FluentValidation;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductAdderService : IProductAdderService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ProductAdderValidator _validator;

        public ProductAdderService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            _validator = new ProductAdderValidator();
        }

        public Task<AddProductResponse> AddProduct(AddProductRequest request)
        {
            _validator.ValidateAndThrow(request);
            throw new NotImplementedException();
        }
    }
}
