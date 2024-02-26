
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
using XUnitCRUDTest.Products;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.Services.CategoryServices;
using System;


namespace XUnitCRUDTest.Categories
{
    public class CategoryAdderServiceTest
    {

        ICategoryAdderService _categoryAdderService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;
        CategoryAdderValidator _validator;

        public CategoryAdderServiceTest(ITestOutputHelper testOutputHelper)
        {
            DbContextMock<AppDbContext> dbContextMock = new DbContextMock<AppDbContext>(
               new DbContextOptionsBuilder<AppDbContext>().Options
               );

            AppDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Categories, SeedData.GetSeedCategories());
            //dbContextMock.CreateDbSetMock(temp => temp.Products, SeedData.GetSeedProducts());



            _testOutputHelper = testOutputHelper;
            _categoryAdderService = new CategoryAdderService(new CategoryRepository(dbContext));
         
            _fixture = new Fixture();
            _validator = new CategoryAdderValidator();
        }

        [Fact]
        public async void AddCategory_CheckArgumentNull_ThrowArgumentNullException()
        {
            AddCategoryRequest addRequest = null;

            Func<Task> action = async () =>
            {
                object value = await _categoryAdderService.AddCategoryAsycn(addRequest);
            };
            _testOutputHelper.WriteLine($"Request: {addRequest}");

            var result = await action.Should().ThrowAsync<ArgumentNullException>();
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");
        }

        [Fact]
        public async void AddCategory_Check_Category_Name_Is_Null_Throw_Argument_Exception()
        {
            AddCategoryRequest addCategoryRequest = _fixture.Build<AddCategoryRequest>().With( x => x.Name , "").Create();

            _testOutputHelper.WriteLine($"Request: {addCategoryRequest.ToJson()}");

            Func<Task> action = async () =>
            {
                await _categoryAdderService.AddCategoryAsycn(addCategoryRequest);
            };

            var result = await action.Should().ThrowAsync<ArgumentException>();
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");
        }

        [Fact]
        public async void AddCategory_Check_Category_Description_Is_Null_Throw_Argument_Exception()
        {
            AddCategoryRequest addCategoryRequest = _fixture.Build<AddCategoryRequest>().With(x => x.Description, "").Create();

            _testOutputHelper.WriteLine($"Request: {addCategoryRequest.ToJson()}");

            Func<Task> action = async () =>
            {
                await _categoryAdderService.AddCategoryAsycn(addCategoryRequest);
            };

            var result = await action.Should().ThrowAsync<ArgumentException>();
            _testOutputHelper.WriteLine($"Resutl: {result ?? null}");
        }

        [Fact]
        public async void AdCategory_ProperCategory_Succed()
        {
            //Arange
            AddCategoryRequest request = _fixture.Build<AddCategoryRequest>()
                .With(x=>x.Id,0)
                .With(x=>x.ParentCategoryId,0)
                .Create();

            //Act

            _testOutputHelper.WriteLine(request.ToJson());
            var result = await _categoryAdderService.AddCategoryAsycn(request);
            _testOutputHelper.WriteLine(result.ToJson());


            result.Should().NotBeNull();

        }
    }

}
