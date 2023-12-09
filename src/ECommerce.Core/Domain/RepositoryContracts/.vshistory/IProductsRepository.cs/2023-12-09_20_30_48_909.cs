

using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.Domain.RepositoryContracts
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
        Product GetProductByName(string productName);
        List<Product> GetAllProducts();

    }
}
