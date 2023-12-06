using ECommerce.Core.DTOs.Request;
using ECommerce.Core.ServiceContracts;
using ECommerce.Core.Services;

namespace XUnitCRUDTest
{
    public class ProductServiceTest
    {
        IProductService _productService;

        public ProductServiceTest(ProductService productService)
        {
            _productService = productService;
        }


        [Fact]
        public void GetProduct_CheckArgumentNull_ThrowArgumentNullExcepiton()
        {

            //Arrange:
            GetProductRequest request = null;

            //Act:


            //Assert:
            Assert.Throws<ArgumentNullException>(
                () => {
                    //Act:
                    _productService.GetProduct(request);
                    }
                );

        }

    }
}
