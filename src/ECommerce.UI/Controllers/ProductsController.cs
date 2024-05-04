using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.UI.Areas.Admin.MVVM;
using ECommerce.UI.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class ProductsController : Controller
    {
        IProductGetterService _productGetterService;
        ProductVM _productVM;



        public ProductsController(IProductGetterService productGettterService,
            GlobalResource globalResource)
        {
            _productGetterService = productGettterService;
            _productVM = new ProductVM(productGettterService);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> Index()
        //{
        //    var result = await _productVM.GetAllProducts();
        //    return View(result);
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromRoute]Guid? id)
        {
            if (id is not null)
            {
                Guid uid = Guid.Parse(id.ToString());
               
                var product = await _productVM.GetProduct(uid);
                return View(viewName: "Details", product);
            }
            var result = await _productVM.GetAllProducts();
            return View(result);
        }
    }
}
