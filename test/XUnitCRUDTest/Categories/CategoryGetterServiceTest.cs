using AutoFixture;
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.Helpers.Extensions;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.Infastructure.Repositories;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using XUnitCRUDTest.Products;

namespace XUnitCRUDTest.Categories
{


    public class CategoryGetterServiceTest
    {

        ICategoryGetterService _categoryGetterService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        CategoryAdderValidator _validator;

        public CategoryGetterServiceTest(ITestOutputHelper testOutputHelper)
        {
            DbContextMock<AppDbContext> dbContextMock = new DbContextMock<AppDbContext>(
               new DbContextOptionsBuilder<AppDbContext>().Options
               );

            var initialEntities = new[]
          {
                 new Category { 
                     Id=1,
                     UId=Guid.NewGuid(),
                     ParentCategoryId=0,
                     Name="Phones",
                     Tags="Phones"
                     ,Description="Telefonlar"}
            }.AsQueryable();

            var initialEntities2 = new[]
        {
                 new Category {
                     Id=2,
                     UId=Guid.NewGuid(),
                     ParentCategoryId=0,
                     Name="Phones",
                     Tags="Phones"
                     ,Description="Telefonlar"}
            };


            AppDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Categories, initialEntities);
            dbContext.Categories.AddRange(initialEntities2);
            dbContext.SaveChanges();




            _testOutputHelper = testOutputHelper;
            _categoryGetterService = new CategoryGetterService(new CategoryRepository(dbContext));

            _fixture = new Fixture();
            _validator = new CategoryAdderValidator();

        }

       

        [Fact]
        public async void AdCategory_GetList()
        {
            //Arange
     

            //Act

            List<Category> result = await _categoryGetterService.GetAllCategoriesASync();
            _testOutputHelper.WriteLine(result.ToJson());


            result.Should().HaveCountGreaterThan(0);

        }


        [Fact]
        public async void GetCategoryById_Succed()
        {
            int i = 1;
            var result = await _categoryGetterService.GetCategoryById(i);
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");
            result.Name.Length.Should().BeGreaterThan(2);
        }
    }

    static class SeedData
    {
        public static List<Category> GetSeedCategories()
        {
            return new List<Category>
            {
                new Category { Name="Phones",Tags="Phones",Description="Telefonlar"},
                new Category { Name="Bilgisayar",Tags="Bilgisayar",Description="Bilgisayar"},

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
                        CategoryId=2,
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
                        CategoryId=3,
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
