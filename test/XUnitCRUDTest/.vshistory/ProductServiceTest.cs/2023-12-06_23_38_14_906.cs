﻿using ECommerce.Core.ServiceContracts;

namespace XUnitCRUDTest
{
    internal class ProductServiceTest
    {
        IProductService _productService;

        public ProductServiceTest(IProductService productService)
        {
            _productService = productService;
        }


        [Fact]
        public void GetProduct_Invalid()
        {

            //Arrange:

            //Act:

            //Assert:


        }
      
    }
}
