using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly CategoryAdderValidator addCategoryValidation;
        private readonly CategoryViewModel<AddCategoryRequest> _categoryVM = 
            new CategoryViewModel<AddCategoryRequest>();

        public CategoryController(ICategoryGetterService categoryGetterService,
            ICategoryAdderService categoryAdderService)
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            addCategoryValidation = new CategoryAdderValidator();
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryGetterService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var x = await _categoryGetterService.GetCategories();            
            ViewBag.Categories = x.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
        

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel<AddCategoryRequest> addCategory)
        {
            _categoryVM.Data = addCategory.Data;
            var x = await _categoryGetterService.GetCategories();
            ViewBag.Categories = x.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            if (!ModelState.IsValid)
            {
                _categoryVM.IsSucced = false;
                return View(_categoryVM);
            }
            try
            {
              
                var addedResponse = await _categoryAdderService.AddCategoryAsycn(addCategory.Data);
                _categoryVM.Data.Id = addedResponse.Id;
                _categoryVM.IsSucced = true;
                _categoryVM.SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id {addedResponse.Id} ";
            }
            catch (Exception ex)
            {

                _categoryVM.IsSucced = false;
                _categoryVM.ErrorMessage = $"İşleminiz sırasında bir hata oluştuştur: Error:{ex.Message}";
            }

            return View(_categoryVM);
        }
    }
}
