

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;   
        }

        public async Product AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _db.Products.ToListAsync();
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
