
using AutoFixture;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitCRUDTest.Products
{
    public class ProductAdderService
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;

        public ProductAdderService()
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductGetterService();
            _fixture = new Fixture();
            _validator = new ProductGetterValidator();
        }
    }
}
