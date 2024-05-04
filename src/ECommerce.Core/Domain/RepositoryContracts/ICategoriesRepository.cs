


using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.Domain.RepositoryContracts
{
    public interface ICategoriesRepository
    {
        Task<Category> AddCategoryAsync(Category value);
        IQueryable<Category> GetAllCategories();
        Task<List<Category>> GetAllCategoriesASync();
        Task<Category> GetCategoryById(int id);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CategoryNameIsExists(string categoryName);
    }
}
