

using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryAdderService
    {
        Task<AddCategoryResponse> AddCategoryAsycn(AddCategoryRequest addRequest);
        Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest updateRequest);
    }
}
