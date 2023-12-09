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
            //_testOutputHelper.WriteLine(request.ToString());

            //Assert:
            Assert.Throws<ArgumentNullException>(
                () => {
                    //Act:
                    _productService.GetProduct(request);
                    }
                );

        }

        [Fact]
        public void GetProduct_GetSuccedResponse_WithProperRequest()
        {

            //Arrange:
            GetProductRequest request = new GetProductRequest { Id=1 };

            //Act:
            _testOutputHelper.WriteLine("this is test");
            var response = _productService.GetProduct(request);

            //Assert:
            Assert.True(response.Id > 0);

        }

    }
}
