

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Infastructure.DbContexts;

namespace ECommerce.Infastructure.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
                
        }

        public Product AddProduct(Product product)
        {
            _db.Products.Add(product);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string productName)
        {
            throw new NotImplementedException();
        }

    }
}
