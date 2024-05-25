
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.ServiceContracts.ProductContracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerce.UI.Areas.Admin.MVVM
{
    public class ProductVM:BaseVM
    {
        IProductAdderService _productAdderService;
        IProductGetterService _productGetterService;

        public ProductVM(IProductAdderService productAdderService,
                          IProductGetterService productGetterService   )
        {
                _productAdderService = productAdderService;
            _productGetterService = productGetterService;
        }

        public ProductVM(IProductGetterService productGetterService)
        {
  
            _productGetterService = productGetterService;
        }


        internal async Task<AddProductResponse> AddProductAsycn(AddProductRequest productToAdd)
        {
            try
            {
                var addedResponse = await _productAdderService.AddProductAsycn(productToAdd);
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id  ";
                return addedResponse;
            }
            catch (Exception ex)
            {
                IsSucced = false;
                ErrorMessage = $"İşelminiz bir hata oluştu" + ex.Message;
                return default;
            }
        }


        internal async Task<List<GetProductResponse>> GetAllProducts()
        {
            try
            {
                var products = await _productGetterService.GetAllProducts();
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id  ";
                return products;
            }
            catch (Exception ex)
            {
                IsSucced = false;
                ErrorMessage = $"İşelminiz bir hata oluştu" + ex.Message;
                return default;
            }
        }
        internal async Task<GetProductResponse> GetProduct(Guid Uid)
        {
            //try
            //{
                var req = new GetProductRequest { UId = Uid };
                var product = await _productGetterService.GetProduct( req) ;
                IsSucced = true;
                SuccedMessage = $"İşelminiz başarılı bir  şekilde tamamlanmıştır: Urun Id  ";
                return product;
            //}
            //catch (Exception ex)
            //{
            //    IsSucced = false;
            //    ErrorMessage = $"İşelminiz bir hata oluştu" + ex.Message;
            //    return default;
            //}
        }

    }
}
