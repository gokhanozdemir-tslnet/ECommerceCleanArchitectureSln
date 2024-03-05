


using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.Domain.RepositoryContracts
{
    public interface ICategoriesRepository
    {
        Task<Category> AddCategoryAsync(Category value);
        IQueryable<Category> GetAllCategories();
        Task<List<Category>> GetAllCategoriesASync();    
    }
}
