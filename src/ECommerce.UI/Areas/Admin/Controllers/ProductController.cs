using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.Infastructure.Repositories;
using ECommerce.UI.Areas.Admin.MVVM;
using ECommerce.UI.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User,Admin")]
    public class ProductController : Controller
    {


        IProductGetterService _productGetterService;
        ProductGetterValidator _validator;
        IProductAdderService _productAdderService;
        CategoryVM _catVM;
        ProductVM _productVM;


        public ProductController(
            IProductGetterService productGettterService,
            IProductAdderService productAdderService,
            ICategoryGetterService categoryGetterService,
            GlobalResource globalResource
            )
        {

            _productGetterService = productGettterService;
            _productAdderService = productAdderService;
            _catVM = new CategoryVM(categoryGetterService, globalResource);
            _productVM = new ProductVM(
                productAdderService,
                productGettterService
                );
            //_validator = new ProductGetterValidator();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList = await _productGetterService.GetAllProducts();
            return View(productList);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            

            var categories = await _catVM.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest productToAdd)
        {

            var categories = await _catVM.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            if (ModelState.IsValid)
            {
                await _productVM.AddProductAsycn(productToAdd);
                ViewBag.IsSucced = _productVM.IsSucced;
                ViewBag.ErrorMessage = _productVM.ErrorMessage;
                ViewBag.SuccedMessage = _productVM.SuccedMessage;
            }
            return View(productToAdd);
        }


    }
}
