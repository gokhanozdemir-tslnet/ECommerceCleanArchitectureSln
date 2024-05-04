
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
        private readonly CategoryUpdaterValidator _updaterValidator;

        public CategoryAdderService(ICategoriesRepository categoryRepository)
        {
            
            _categoryRepository = categoryRepository;
            _validator = new CategoryAdderValidator();
            _updaterValidator = new CategoryUpdaterValidator();
        }

        public async Task<AddCategoryResponse> AddCategoryAsycn(AddCategoryRequest addRequest)
        {
            //throw new Exception("sdfsdfsf");
            _validator.ValidateAndThrow(addRequest);
            addRequest.Name = addRequest.Name.ToUpper();
            var addedCategory = await _categoryRepository.AddCategoryAsync(addRequest.ToCategory());
            return addedCategory.ToAddCategoryResponse();
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest updateRequest)
        {
            _updaterValidator.ValidateAndThrow(updateRequest);
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(updateRequest.ToCategory());
            return updatedCategory.ToUpdateCategoryResponse();
        }
    }
}
