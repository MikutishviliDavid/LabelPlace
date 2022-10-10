using LabelPlace.Api.ViewModels;
using LabelPlace.BusinessLogic.CustomExceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LabelPlace.Api.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _request;

        public ExceptionHandler(RequestDelegate pipeline)
        {
            _request = pipeline;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case BusinessLogicNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    //context.Response. - for  Message +-
                    break;
                default:
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
