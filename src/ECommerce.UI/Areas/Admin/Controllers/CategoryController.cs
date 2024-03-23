using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly CategoryAdderValidator addCategoryValidation;

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
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequest addCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(addCategory);
            }

            var result = await _categoryAdderService.AddCategoryAsycn(addCategory);

            return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
