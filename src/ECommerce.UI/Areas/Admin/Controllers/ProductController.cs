using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.Infastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {


        IProductGetterService _productGetterService;      
        ProductGetterValidator _validator;
       IProductAdderService _productAdderService;


        public ProductController(
            IProductGetterService productGettterService, 
            IProductAdderService productAdderService
            )
        {

            _productGetterService = productGettterService;
            _productAdderService = productAdderService;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest productToAdd)
        {

            if (!ModelState.IsValid)
            {
                return View(productToAdd);
            }

            return RedirectToAction(nameof(Index));
            //Act
            var createdProduct =productToAdd;// await _productAdderService.AddProductAsycn(productToAdd);


            return View(createdProduct);
        }


    }
}
