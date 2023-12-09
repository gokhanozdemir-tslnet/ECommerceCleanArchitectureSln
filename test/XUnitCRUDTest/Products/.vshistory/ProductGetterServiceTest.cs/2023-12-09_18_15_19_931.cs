

using AutoFixture;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using Xunit.Abstractions;

namespace XUnitCRUDTest.Products
{
    public class ProductGetterServiceTest
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;

    }
}
