
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using FluentValidation;

namespace ECommerce.Core.Services.CategoryServices
{
    public class CategoryAdderService : ICategoryAdderService
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly CategoryAdderValidator _validator;

        public CategoryAdderService(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _validator = new CategoryAdderValidator();
        }

        public async Task<AddCategoryResponse> AddCategoryAsycn(AddCategoryRequest addRequest)
        {
            throw new Exception("sdfsdfsf");
            _validator.ValidateAndThrow(addRequest);
            var addedCategory = await _categoryRepository.AddCategoryAsync(addRequest.ToCategory());

            return addedCategory.ToCategory();
        }
    }
}
