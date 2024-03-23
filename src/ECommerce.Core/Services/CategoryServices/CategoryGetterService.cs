

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;

namespace ECommerce.Core.Services.CategoryServices
{
    public class CategoryGetterService: ICategoryGetterService
    {
        private readonly ICategoriesRepository _categoryRepository;
        //private readonly CategoryAdderValidator _validator;

        public CategoryGetterService(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            //_validator = new CategoryAdderValidator();
        }

        public async Task<IQueryable<GetCategoryResponse>> GetCategories()
        {
            return _categoryRepository.GetAllCategories().Select(x=>x.ToGetCategoryResponse());
        }
        public async Task<List<Category>> GetAllCategoriesASync()
        {
            return await _categoryRepository.GetAllCategoriesASync();
        }
    }
}
