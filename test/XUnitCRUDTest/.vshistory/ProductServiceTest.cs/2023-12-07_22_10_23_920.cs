using ECommerce.Core.DTOs.Request;
using ECommerce.Core.ServiceContracts;
using ECommerce.Core.Services;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
    {
        IProductService _productService;
        ITestOutputHelper _testOutputHelper;

      

        public ProductServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductService();
        }

        [Fact]
        public void GetProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {

            //Arrange:
            GetProductRequest request = null;

            //Act:
            _testOutputHelper.WriteLine("this is test");

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
