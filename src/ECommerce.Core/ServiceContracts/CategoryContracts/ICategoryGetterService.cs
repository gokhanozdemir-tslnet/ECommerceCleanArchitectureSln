
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryGetterService
    {
        Task<IQueryable<GetCategoryResponse>> GetCategories();
        Task<List<Category>> GetAllCategoriesASync();
    }
}
