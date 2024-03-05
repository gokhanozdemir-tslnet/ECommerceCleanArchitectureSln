
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.Repositories
{
    public class CategoryRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
                _db = db;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            var resutl = await _db.SaveChangesAsync();
            return category;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories.AsQueryable();
        }

        public async Task<List<Category>> GetAllCategoriesASync()
        {
            return await _db.Categories.ToListAsync();
        }

      
    }
}
