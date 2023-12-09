
using AutoFixture;
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
                new ProductRepository(
                );
            _fixture = new Fixture();
            _validator = new ProductGetterValidator();
        }
    }
}
