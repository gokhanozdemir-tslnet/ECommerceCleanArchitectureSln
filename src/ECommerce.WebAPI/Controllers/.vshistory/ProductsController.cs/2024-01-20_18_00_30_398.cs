
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public async Task<ApiResponse<List<GetProductResponse>>> Get(GetProductRequest? reg)
        {

            var resultdata = new List<GetProductResponse>
            {
                new GetProductResponse
                {
                    Id = 1,
                    Category = new Category
                    {
                        Id=1,
                        Name="test Product"
                    },
                    Title = "Phone",
                    
                }
            };

            return new ApiResponse<List<GetProductResponse>>
            {
                Result = true,
                Data = resultdata

            };
        }
    }
}
