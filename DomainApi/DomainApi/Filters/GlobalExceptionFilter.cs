using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DomainApi.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            //We can log the error using NLog or any other logging library

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new { error = "Oops! Sorry! Something went wrong. Please contact administrator." });
        }
    }
}