namespace ECommerce.WebAPI.Common
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Result { get; set; }   
        public Error Error { get; set; }
    }


    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}
