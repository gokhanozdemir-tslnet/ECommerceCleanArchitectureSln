

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
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

        public async Task<Product> AddProductAsync(Product product)
        {
             await _db.Products.AddAsync(product);
            var x =await _db.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync(GetProductsWithPagingRequest listParams)
        {
            return await _db.Products
                .OrderBy(x=> x.Title)
                .Skip((listParams.PageNumber-1)*listParams.PageSize)
                .Take(listParams.PageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductByUId(Guid productUId)
        {
            
            var result = await _db.Products.FirstOrDefaultAsync(x=>x.UId == productUId);
            return result;

        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var result = await _db.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return result;
            //Notes: https://code-maze.com/csharp-sql-like-operator-with-linq/
        }

        public async Task<List<Product>> GetProductsByName(string title)
        {
            var result = await _db.Products.Where(x => x.Title.Contains(title)).ToListAsync();
            return result;
        }

        public Task<List<Product>> GetProductsByTitle(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
