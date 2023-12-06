using ECommerce.Core.DTOs.Request;
using ECommerce.Core.ServiceContracts;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
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
            GetProductRequest request = null;

            //Act:


            //Assert:


        }
      
    }
}
