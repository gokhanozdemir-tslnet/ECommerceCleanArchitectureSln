﻿
using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.Repositories;
using Xunit.Abstractions;
using FluentAssertions;
using ECommerce.Core.Helpers.Extensions;

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
                await _productService.AddProduct(addRequest);
            };

            var result = await action.Should().ThrowAsync<ArgumentException>();
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");

        }
    }
}
