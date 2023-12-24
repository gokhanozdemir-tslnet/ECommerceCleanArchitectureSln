using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.ServiceContracts.ProductContracts;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductAdderService : IProductAdderService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductAdderService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<AddProductResponse> AddProduct(AddProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
