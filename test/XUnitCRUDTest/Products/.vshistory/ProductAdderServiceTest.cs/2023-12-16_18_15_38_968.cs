
using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.Repositories;
using Xunit.Abstractions;

namespace XUnitCRUDTest.Products
{
    public class ProductAdderService
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;

        public ProductAdderService(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductGetterService(
                new ProductRepository()
                );
            _fixture = new Fixture();
            _validator = new ProductGetterValidator();
        }


        [Fact]
        public void AddProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {
            //Arrange:
            GetProductRequest request = null;

            //Act:
            _testOutputHelper.WriteLine("this is test");
            //_testOutputHelper.WriteLine(request.ToString());
            //var response = _validator.Validate(request);

            //Assert:
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    //Act:
                    _productService.GetProduct(request);
                }
            );
        }
    }
}
