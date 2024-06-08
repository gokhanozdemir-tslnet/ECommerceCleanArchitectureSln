using Autofac.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System;
using System.Text;
using ECommerce.WebAPI.Model.Common;
using ECommerce.Core.Helpers.Extensions;
using Serilog;

namespace ECommerce.WebAPI.Filters
{
    public class GlobalExceptionHandlerFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlerFilter> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        public GlobalExceptionHandlerFilter(ILogger<GlobalExceptionHandlerFilter> logger, IDiagnosticContext diagnosticContext)
        {
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }      

        public void OnException(ExceptionContext filterContext)
        {
            
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            //filterContext.Result = new Viewresult ??*

            string exceptionMessage = string.Empty;
            if (filterContext.Exception.InnerException == null)
            {
                exceptionMessage = filterContext.Exception.Message;
            }
            else
            {
                exceptionMessage = filterContext.Exception.InnerException.Message;
            }       

            filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.ContentType = "application/json";
            filterContext.HttpContext.Response.WriteAsJsonAsync(new ApiResponse<string> {  Succeeded=false, Message= "bir hata oluştu" });          


            _logger.LogError(exceptionMessage);
            _diagnosticContext.Set("xxxxxxxxxxxxxxxxxxxxxx:", "benim parametrelerim");
        }

        //private string GetErroLogMessage(ExceptionContext context)
        //{
        //    var stringBuilder = new StringBuilder();
        //    stringBuilder.Append("Parameters :[");
        //    foreach (var item in context.ModelState.Keys)
        //    {
        //        stringBuilder.Append($"{item}:{context.ModelState[item]?.RawValue} ,");
        //    }
        //    stringBuilder.Append("]");
        //    string parameters = stringBuilder.ToString();
        //    //The output is as follows : parameters:[foo:bar]

        //    //Continuation of previous codes...    
        //    return parameters;
        //}
    }
}
