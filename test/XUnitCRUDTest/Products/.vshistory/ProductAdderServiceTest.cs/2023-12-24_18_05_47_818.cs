
using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.Repositories;
using Xunit.Abstractions;
using FluentAssertions;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Infastructure.DbContexts;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

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


            DbContextMock<AppDbContext> dbContextMock = new DbContextMock<AppDbContext>(
                new DbContextOptionsBuilder<AppDbContext>().Options
                );

            AppDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Categories, SeedData.GetSeedCategories());
            dbContextMock.CreateDbSetMock(temp => temp.Products, SeedData.GetSeedProducts());


            _testOutputHelper = testOutputHelper;
            _productService = new ProductAdderService(
                new ProductRepository(null)
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
                await _productService.AddProductAsycn(addRequest);
            };
            _testOutputHelper.WriteLine($"Request: {addRequest}");

            var result = await action.Should().ThrowAsync<ArgumentNullException>();
            _testOutputHelper.WriteLine($"Resutl: {result??null}");
        }

        [Fact]
        public async void AddProduct_CheckProductTitleIfNull_ThrowArgumentException()
        {
            AddProductRequest addRequest = _fixture.Build<AddProductRequest>()
                .With(temp => temp.Title, "")
                .Create();

            _testOutputHelper.WriteLine($"Request: {addRequest.ToJson()}");
            Func<Task> action = async () =>
            {
                await _productService.AddProductAsycn(addRequest);
            };

            var result = await action.Should().ThrowAsync<ArgumentException>();
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");
            _testOutputHelper.WriteLine($"{result.Subject.ToJson()}");

        }

        [Fact]
        public async void AddProduct_CheckProductPriceIfNegativeOrZero_ThrowArgumentException()
        {

            AddProductRequest addRequestZeroPrice = _fixture.Build<AddProductRequest>()
                .With(temp => temp.Price, 0M)
                .Create();
            AddProductRequest addRequestnegativePrice = _fixture.Build<AddProductRequest>()
                .With(temp => temp.Price, -1M)
                .Create();

            _testOutputHelper.WriteLine($"Request: {addRequestnegativePrice.ToJson()}");
            Func<Task> action1 = async () =>
            {
                await _productService.AddProduct(addRequestnegativePrice);
            };

            var result1 = await action1.Should().ThrowAsync<ArgumentException>();
            var result2 = await action1.Should().ThrowAsync<ArgumentException>();
            _testOutputHelper.WriteLine($"Resutl1: {result1 ?? null}");
            _testOutputHelper.WriteLine($"{result1.Subject.ToJson()}");
            _testOutputHelper.WriteLine($"Resutl2: {result2 ?? null}");
            _testOutputHelper.WriteLine($"{result2.Subject.ToJson()}");
        }


        [Fact]
        public async void AddProduct_ProperProduct_Succed()
        {
            //Arange
            AddProductRequest request = _fixture.Build<AddProductRequest>()
                .With(x=>x.ImageUrl,"www.product.com.tr")
                .Create();

            //Act
            var x = _productService.AddProductAsycn(request);

        }
    }
}
