namespace ECommerce.WebAPI.Common
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Result { get; set; }   
        public bool ApiError { get; set; }
    }
    public class ApiError
    {
       public  List<Error> Errors { get; set; }        
    }

    public class Error
    {
        public int ErrorCode { get; set; }
        public string 
    }

}
