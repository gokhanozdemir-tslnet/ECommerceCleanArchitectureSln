using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User,Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly CategoryViewModel<AddCategoryRequest> _categoryVM = 
            new CategoryViewModel<AddCategoryRequest>();
        private readonly IDiagnosticContext _diagnoserContext;

        public CategoryController(ICategoryGetterService categoryGetterService,
            ICategoryAdderService categoryAdderService,
            IDiagnosticContext diagnostic)
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            _diagnoserContext = diagnostic;
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryGetterService.GetCategories();
            return View(categories);
        }

        #region Create
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
            _diagnoserContext.Set("Category", addCategory);
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
        #endregion
    }
}
