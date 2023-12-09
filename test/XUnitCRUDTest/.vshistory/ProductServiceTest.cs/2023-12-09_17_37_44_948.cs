﻿using AutoFixture;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.ProductServices;
using Xunit.Abstractions;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
    {
        IProductGetterService _productService;
        ITestOutputHelper _testOutputHelper;
        Fixture _fixture;

      

        public ProductServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _productService = new ProductGetterService();
            _fixture = new Fixture();
        }

        [Fact]
        public void GetProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {

            //Arrange:
            GetProductRequest request = null;

            //Act:
            _testOutputHelper.WriteLine("this is test");
            //_testOutputHelper.WriteLine(request.ToString());

            //Assert:
            Assert.Throws<ArgumentNullException>(
                () => {
                    //Act:
                    _productService.GetProduct(request);
                    }
                );

        }

        [Fact]
        public void GetProduct_GetSuccedResponse_WithProperRequest()
        {

            //Arrange:
            GetProductRequest request = _fixture.Create<GetProductRequest>();


            //Act:
            _testOutputHelper.WriteLine("this is test");
            var response = _productService.GetProduct(request);

            //Assert:
            Assert.True(response.Id > 0);

        }

    }
}
