using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorMoldels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.CustomMiddlewares
{
    public class CustomExceptionHandlerMiddleware(RequestDelegate _next , ILogger<CustomExceptionHandlerMiddleware> _logger)
    {
        private readonly RequestDelegate next = _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger = _logger;

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await next.Invoke(httpcontext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while processing the request.");
                httpcontext.Response.StatusCode = ex switch {
                    NotFoundExcpetion => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                httpcontext.Response.ContentType = "application/json";

                var errorResponse = new ErrorToReturn()
                {
                    StatusCode = httpcontext.Response.StatusCode,
                    ErrorMessage = ex.Message
                };
                //var ResponseToReturn = JsonSerializer.Serialize(errorResponse);
                //await httpcontext.Response.WriteAsync(ResponseToReturn);
                await httpcontext.Response.WriteAsJsonAsync(errorResponse);
            }
           
        }

    }
}
