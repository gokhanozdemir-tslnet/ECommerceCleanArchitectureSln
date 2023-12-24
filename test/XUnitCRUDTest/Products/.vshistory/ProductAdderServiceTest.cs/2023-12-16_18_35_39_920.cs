
using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.Repositories;
using Xunit.Abstractions;
using FluentAssertions;

namespace XUnitCRUDTest.Products
{
    public class ProductAdderServiceTest
    {
        IProductAdderService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;

        public ProductAdderServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductAdderService(
                new ProductRepository()
                );
            _fixture = new Fixture();
            _validator = new ProductGetterValidator();
        }


        [Fact]
        public async void AddProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {
            //Arrange
            AddProductRequest addRequest = null;
            Func<Task> action = async () =>
            {
                await _productService.AddProduct(addRequest);
            };


            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
