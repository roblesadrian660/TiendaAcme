using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Applicacion.Tecnofactory.WebApi.Handlers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,        // 400
                InvalidOperationException => (int)HttpStatusCode.BadRequest, // 400
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
                _ => (int)HttpStatusCode.InternalServerError // 500 por defecto
            };

            var response = new
            {
                message = exception.Message,
                innerException = exception.InnerException
            };

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
