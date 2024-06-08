
namespace ECommerce.Core.DTOs.Request
{
    public class GetProductsWithPagingRequest
    {
        public const int _maxPageSize = 50;
        public int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > _maxPageSize) ? _maxPageSize : value; }
        }
    }
}
