using Azure;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.UI.Areas.Admin.Models;
using ECommerce.UI.Areas.Admin.MVVM;
using ECommerce.UI.Resources;
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
        private readonly CategoryViewModel<AddCategoryRequest> _categoryVM;
        private readonly IDiagnosticContext _diagnoserContext;
        private readonly GlobalResource _globalResource;
        CategoryVM _catVM;

        public CategoryController(ICategoryGetterService categoryGetterService,
                                  ICategoryAdderService   categoryAdderService,
                                  IDiagnosticContext                diagnostic,
                                  GlobalResource globalResource
                                  )
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            _diagnoserContext = diagnostic;
            _globalResource = globalResource;
            _categoryVM = new CategoryViewModel<AddCategoryRequest>();

            _catVM = new CategoryVM(_categoryGetterService,categoryAdderService,globalResource);

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _catVM.GetCategories();             
            ViewBag.IsSucced = _catVM.IsSucced;
            ViewBag.ErrorMessage =  _catVM.ErrorMessage;
            ViewBag.SuccedMessage = _catVM.SuccedMessage;
            return View(categories);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var categories = await _catVM.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequest addCategory)
        {
            _diagnoserContext.Set("Category", addCategory);
            _categoryVM.Data = addCategory;


            var categories = await _catVM.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            if (!ModelState.IsValid)
            {
                _categoryVM.IsSucced = false;              
            }
            else
            {
                await _catVM.AddCategoryAsycn(addCategory);
                ViewBag.IsSucced = _catVM.IsSucced;
                ViewBag.ErrorMessage = _catVM.ErrorMessage;
                ViewBag.SuccedMessage = _catVM.SuccedMessage;
            }             
            return View(addCategory);
        }
        #endregion
        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
          
            var result = await _catVM.GetCategoryById(id);
            ViewBag.IsSucced = _catVM.IsSucced;
            ViewBag.ErrorMessage = _catVM.ErrorMessage;
            ViewBag.SuccedMessage = _catVM.SuccedMessage;

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryRequest category)
        {
            if (!ModelState.IsValid)
            {
                _categoryVM.IsSucced = false;
                return View(category.ToGetCategoryResponse());
            }

            var categories = await _catVM.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            await _catVM.UpdateCategoryAsync(category);
            ViewBag.IsSucced = _catVM.IsSucced;
            ViewBag.ErrorMessage = _catVM.ErrorMessage;
            ViewBag.SuccedMessage = _catVM.SuccedMessage;

            return View(category.ToGetCategoryResponse());
        }
        #endregion

    }
}
