using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyMarket.Communication.Response;
using MyMarket.Exceptions.Exceptions;
using MyMarket.Exceptions.Resources;
using System.Net;

namespace MyMarket.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyMarketException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException error)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(error.MessageErrors));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
             context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
             context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.GENERIC_UNKNOWN_ERROR));
        }
    }
}
