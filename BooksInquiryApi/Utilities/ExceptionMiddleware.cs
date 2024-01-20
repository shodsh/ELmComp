using Microsoft.AspNetCore.Http;
using Savvy.Services.API.Contracts.V1.Responses;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Savvy.Services.API.Utilities
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Guid exceptionId = Guid.NewGuid();
                string errorMessage = $"{ex.Message} : {ex.StackTrace} : {ex.InnerException}";
                Log.Error($"Something went wrong:Exception ID {exceptionId} : {errorMessage}:");
                await HandleExceptionAsync(httpContext, exceptionId, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Guid exceptionId, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetailsResponse()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ExceptionId = exceptionId,
                Success = false
            }.ToString());
        }

    }
}
