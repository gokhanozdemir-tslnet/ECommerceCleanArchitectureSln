using ECommerce.Core.DTOs.Request;
using ECommerce.Core.ServiceContracts;
using ECommerce.Core.Services;
using Xunit.Abstractions;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
    {
        IProductService _productService;
        ITestOutputHelper testOutputHelper;

        public ProductServiceTest()
        {
            _productService = new ProductService();
        }


        [Fact]
        public void GetProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {

            //Arrange:
            GetProductRequest request = null;

            //Act:


            //Assert:
            Assert.Throws<ArgumentNullException>(
                () => {
                    //Act:
                    _productService.GetProduct(request);
                    }
                );

        }

    }
}
