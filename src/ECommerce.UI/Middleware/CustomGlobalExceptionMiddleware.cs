

using Serilog;

namespace ECommerce.UI.Middleware
{
    public class CustomGlobalExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<CustomGlobalExceptionMiddleware> _logger;
        private readonly IDiagnosticContext _diagnosticContext; 
        public CustomGlobalExceptionMiddleware(RequestDelegate next, 
            ILogger<CustomGlobalExceptionMiddleware> logger,
            IDiagnosticContext diagnosticContext)
        {
            _next = next;
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null)
                {
                    _logger.LogError("{ExceptionType} {ExceptionMessage}",
                        ex.InnerException.GetType(),ToString(),
                        ex.InnerException.Message
                        );
                }
                else
                {
                    _logger.LogError("{ExceptionType} {ExceptionMessage} {ExceptionMessage}",
                        ex.GetType(), ToString(),
                        ex.Message,
                        ex.Source
                        );
                    _diagnosticContext.SetException(ex);
                    
                }
          
                
            }
        }
    }

 
    public static class CustomGlobalExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomGlobalExceptionMiddleware>();

        }
    }
}