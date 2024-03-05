
using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryGetterService
    {
        IQueryable<Category> GetCategories();
        Task<List<Category>> GetAllCategoriesASync();
    }
}
