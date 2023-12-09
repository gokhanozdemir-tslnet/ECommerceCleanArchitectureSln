using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;

      

        public ProductServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductGetterService();
            _fixture = new Fixture();
            _validator = new ProductGetterValidator();
        }

        [Fact]
        public void GetProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {

            //Arrange:
            GetProductRequest request = null;

            //Act:
            _testOutputHelper.WriteLine("this is test");
            //_testOutputHelper.WriteLine(request.ToString());
            var response = _validator.Validate(request);

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
            GetProductRequest request = _fixture.Create<GetProductRequest>();


            //Act:
            _testOutputHelper.WriteLine("this is test");
            var response = _productService.GetProduct(request);

            //Assert:
            Assert.True(response.Id > 0);

        }

    }
}
