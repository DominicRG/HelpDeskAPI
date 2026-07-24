using HelpDesk.Shared.Exceptions;
using HelpDesk.Shared.Responses;
using System.ComponentModel.DataAnnotations;

namespace HelDesk.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) { 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception) {
            var statusCode = exception switch
            {
                HelpDesk.Shared.Exceptions.ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                BusinessException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponseFactory.Failure<string>(exception.Message);
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
