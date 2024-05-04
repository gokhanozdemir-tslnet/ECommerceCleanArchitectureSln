


namespace ECommerce.Core.Exceptions
{
    public class CategoryIsExsistExceptions : ArgumentException
    {
        public CategoryIsExsistExceptions():base() { }

        public CategoryIsExsistExceptions(string? message):base(message) { }

        public CategoryIsExsistExceptions(string? message, Exception? innerException):base(message, innerException) { }
    }
}
