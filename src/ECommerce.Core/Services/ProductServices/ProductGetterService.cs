
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Core.Helpers.Mapper;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        ProductGetterValidator _validator;
        IProductsRepository _productsRepository;
        IMemoryCache _cache;

        public ProductGetterService(IProductsRepository productsRepository,IMemoryCache cache)
        {
            _validator = new ProductGetterValidator();
            _productsRepository = productsRepository;
            _cache = cache;

        }

        public async Task<List<GetProductResponse>> GetAllProducts(GetProductsWithPagingRequest request)
        {
            try
            {

                string key = "GetAllProducts_GetProductsWithPagingRequest_" + request.PageNumber.ToString() + "_" + request.PageSize.ToString() + "_";
                if (!_cache.TryGetValue(request.ToJson(), out List<Product> products))
                {

                    products = await _productsRepository.GetAllProductsAsync(request);
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                        .SetPriority(CacheItemPriority.Normal);
                  
                    _cache.Set(key, products, cacheOptions);
                }
                return products.Select(product => product.ToGetProductResponse()).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

           
              //.Select(temp => temp.ToPersonResponse()).ToList();
        }       
        public async Task<GetProductResponse> GetProductByUId(Guid id)
        {
            var product = await _productsRepository.GetProductByUId(id);
            return product.ToGetProductResponse();
        }
        public async Task<List<GetProductResponse>> GetProductsByTitle(string title)
        {
            var products = await _productsRepository.GetProductsByTitle(title);
            return products.Select(product => product.ToGetProductResponse()).ToList();
        }
        public async Task<List<GetProductResponse>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productsRepository.GetProductsByCategoryId(categoryId);
            return products.Select(product => product.ToGetProductResponse()).ToList();

        }



        public async Task<GetProductResponse> GetProduct(GetProductRequest request)
        {

            _validator.ValidateAndThrow(request);
            var product = await _productsRepository.GetProductByUId(request.UId);
            return product.ToGetProductResponse();
  
        }

       
    }


}
