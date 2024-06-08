

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;

namespace ECommerce.Core.Domain.RepositoryContracts
{
    public interface IProductsRepository
    {
        Task<Product> GetProductByUId(Guid productId);
        Task<List<Product>> GetProductsByTitle(string productName);
        Task<List<Product>> GetProductsByCategoryId(int categoryId);
        Task<List<Product>> GetAllProductsAsync(GetProductsWithPagingRequest listParams);
        
        Task<Product> AddProductAsync(Product product);


    }
}
