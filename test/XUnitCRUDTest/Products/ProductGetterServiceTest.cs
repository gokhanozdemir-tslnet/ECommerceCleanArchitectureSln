using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using Xunit.Abstractions;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Infastructure.Repositories;
using EntityFrameworkCoreMock;
using ECommerce.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using ECommerce.Core.Domain.Entities;
using System.Drawing.Text;
using FluentAssertions;


namespace XUnitCRUDTest.Products
{

    public class ProductGetterServiceTest
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        ProductGetterValidator _validator;


        public ProductGetterServiceTest(ITestOutputHelper testOutputHelper)
        {

            DbContextMock<AppDbContext> dbContextMock = new DbContextMock<AppDbContext>(
                new DbContextOptionsBuilder<AppDbContext>().Options
                );

            AppDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Categories, SeedData.GetSeedCategories());
            dbContextMock.CreateDbSetMock(temp => temp.Products, SeedData.GetSeedProducts());


            _testOutputHelper = testOutputHelper;
            _productService = new ProductGetterService(new ProductRepository(dbContext));
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

        [Fact]
        public void GetProduct_ProductIdIsZero_ThrowArgumentException()
        {
            GetProductRequest request = new();
            request.Id = 0;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    _productService.GetProduct(request);
                }
                );
        }

        [Fact]
        public void GetProduct_WithValidID_GetSuccedResponse()
        {
            GetProductRequest getProductRequest = _fixture.Create<GetProductRequest>();
            _testOutputHelper.WriteLine($"Product.Id {getProductRequest.Id}");

            var response = _productService.GetProduct(getProductRequest);
            _testOutputHelper.WriteLine($"Response: {response.ToJson()}");
            Assert.True(response.Title == "Phone");

        }

        [Fact]
        private async void GetAllProducts()
        {
           var list = await _productService.GetAllProducts();
            _testOutputHelper.WriteLine(list.ToJson());

            list.Should().HaveCountGreaterThan(0);
            
        }
    }

    static class SeedData
    {
        public static List<Category> GetSeedCategories()
        {
            return new List<Category>
            {
                new Category { Name="Phones",Tags="Phones",Description="Telefonlar"},
               
            };
        }
        public static List<Product> GetSeedProducts()
        {
            return new List<Product>
                {
                    new Product
                    {
                        Id = 1, 
                        CategoryId=1,
                        Price = 80000M,
                        Rate = 10,
                        Stock = 100,
                        ImageUrl ="wwww",
                        Title = "Iphone 15",
                        Details = new List<ProductDetail> { new ProductDetail { Id = 1,Description="this is the test desc" } }
                    },
                     new Product
                    {
                        Id = 2,
                        CategoryId=1,
                        Price = 60000M,
                        Rate = 10,
                        Stock = 100,
                        ImageUrl ="wwww",
                        Title = "Iphone 14",
                        Details = new List<ProductDetail> { new ProductDetail { Id = 1,Description="this is the test desc" } }
                    },
                      new Product
                    {
                        Id = 3,
                        CategoryId=1,
                        Price = 80000M,
                        Rate = 10,
                        Stock = 100,
                        ImageUrl ="wwww",
                        Title = "Samsung",
                        Details = new List<ProductDetail> { new ProductDetail { Id = 1,Description="this is the test desc" } }
                    }

                };

        }
    }
}



// GetProductRequest request = _fixture.Create<GetProductRequest>();