using MercadoTesteAZ.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Extensions
{
    public sealed class ExceptionMiddleware
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
            catch (ExcecaoPersonalizada ex)
            {
                await HandleExceptionAsync(context, ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = "Ocorreu um erro ao processar sua requisição.",
                Detail = message,
                Instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
