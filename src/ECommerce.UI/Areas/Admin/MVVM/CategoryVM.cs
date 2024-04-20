using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.UI.Areas.Admin.Models;
using ECommerce.UI.Resources;

namespace ECommerce.UI.Areas.Admin.MVVM
{
    public class CategoryVM
    {
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly GlobalResource _globalResource;


        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccedMessage { get; set; } = string.Empty;
        public bool IsSucced { get; set; }



        public CategoryVM(ICategoryGetterService categoryGetterService,
                          ICategoryAdderService categoryAdderService,
                          GlobalResource globalResource
            )
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            _globalResource = globalResource;
        }

        internal async Task<IQueryable<GetCategoryResponse>> GetCategories()
        {

            try
            {

                SuccedMessage = _globalResource.Get("ErrorCommonMessage");
                IsSucced = true;
                return await _categoryGetterService.GetCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = _globalResource.Get("ErrorCommonMessage");
                return default;

            }



        }

        internal async Task<AddCategoryResponse> AddCategoryAsycn(AddCategoryRequest data)
        {
            try
            {
                var addedResponse = await _categoryAdderService.AddCategoryAsycn(data);
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id {addedResponse.Id} ";
                return addedResponse;
            }
            catch (Exception)
            {
                IsSucced = false;
                ErrorMessage = $"İşelminiz bir hata oluştu";
                return default;
            }
        }

        internal async Task<GetCategoryResponse> GetCategoryById(int id)
        {
            try
            {
                var result = await _categoryGetterService.GetCategoryById(id);
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id {id.ToString()} ";
                return result;
            }
            catch (Exception)
            {

                IsSucced = false;
                ErrorMessage = $"İşelminiz bir hata oluştu";
                return default;
            }
        }

        internal async Task UpdateCategoryAsync(UpdateCategoryRequest category)
        {
            try
            {
                await _categoryAdderService.UpdateCategoryAsync(category);
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id {category.Id.ToString()} ";
             
            }
            catch (Exception)
            {

                IsSucced = false;
                ErrorMessage = $"İşelminiz bir hata oluştu";
            }
        }
    }
}
