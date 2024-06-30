
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.ServiceContracts;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.WebAPI.Configuration.Object;
using ECommerce.WebAPI.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.AccessControl;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "User")]
    [AllowAnonymous]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductGetterService _productGetterService;
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly IProductAdderService _productAdderService;

        public ProductsController(IProductGetterService productGetterService, ICategoryGetterService categoryGetterService)
        {
            _productGetterService = productGetterService;
            _categoryGetterService = categoryGetterService;
        }

        //[HttpGet("{pagenumber=1:int}/{pagesize=50:int}")]
        [HttpGet()]
        public async Task<ApiResponse<List<GetProductResponse>>> GetAllProducts([FromServices] IOptionsSnapshot<DatabaseOption> dbOption,
            [FromQuery] GetProductsWithPagingRequest productsParams
            )
        {

            #region MyNotes
            //burda kalındı: https://code-maze.com/paging-aspnet-core-webapi/
            //https://www.tutlane.com/tutorial/aspnet-mvc/global-action-filters-in-asp-net-mvc-for-exception-handling-and-logging
            //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-8.0 
            #endregion
            var products =await _productGetterService.GetAllProducts(productsParams);
            return new ApiResponse<List<GetProductResponse>>
            {
                Succeeded = true,
                Data = products

            };
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<GetProductResponse>> GetProductByUId(Guid id)
        {
            var product = await _productGetterService.GetProductByUId(id);

            return new ApiResponse<GetProductResponse>
            {
                Succeeded = true,
                Data = product,
                Message = ""
            };
        }
        //[HttpGet("{title}")]
        //public async Task<ApiResponse<List<GetProductResponse>>> GetProductsByTitle(string title)
        //{
        //    var products = await _productGetterService.GetProductsByTitle(title);

        //    return new ApiResponse<List<GetProductResponse>>
        //    {
        //        Succeeded = true,
        //        Data = products,
        //        Message = ""
        //    };
        //}
        //[HttpGet("{categoryUId")]
        //public async Task<ApiResponse<List<GetProductResponse>>> GetProductsByCategoryUId(Guid categoryUId)
        //{
        //    var category = await _categoryGetterService.GetCategoryByUId(categoryUId);
        //    var products = await _productGetterService.GetProductsByCategoryId(category.Id);
        //    return new ApiResponse<List<GetProductResponse>>
        //    {
        //        Succeeded = true,
        //        Data = products,
        //        Message = ""
        //    };
        //}


        //[HttpPost]
        //public async Task<ApiResponse<AddProductResponse>> CreateProduct(AddProductRequest request)
        //{
        //    var result = await _productAdderService.AddProductAsycn(request);
        //    return new ApiResponse<AddProductResponse>
        //    {
        //        Succeeded = true,
        //        Data = result,
        //        Message = ""
        //    };
        //}



        //BEST PRACTICE 
        //createProduct =>          endpoint: /products                             method: Post         bodyparam: ProductAddReq      return: Product
        //updateProduct =>          endpoint: /products/{id}                        method: Put          bodyparam: -                  return: Product
        //deleteProduct =>          endpoint: /products/{id}                        method: Delete       bodyParam  -                  return: bool
        //listProducts  =>          endpoint: /products                             method: Get          bodyparam: -                  return: List<Product>
        //listProductsByCategory => endpoint: /products?categoryId={categoryId}     method: Get          bodyparam: -                  return: List<Product>
        //searchProductsByTitle =>   endpoint: /products?title={title}              method: Get          bodyparam: -                  return: List<Product>
        //getProductById        =>   endpoint: /products/{id}                       method: Get          bodyparam: -                  return: Product

        //Patch: Partial update

    }
}
