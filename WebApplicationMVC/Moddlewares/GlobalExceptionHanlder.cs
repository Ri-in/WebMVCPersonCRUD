using System.Text.Json;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public GlobalExceptionHandler()
        {

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = GetStatusCode(ex);

            var response = context.Response;


            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            ErrorDetails errorDetails = new()
            {
                Message = ex.Message,
                StatusCode = statusCode
            };

            string result = JsonSerializer.Serialize(errorDetails);

            await response.WriteAsJsonAsync(result);
        }

        private static int GetStatusCode(Exception ex)
        {
            return ex switch
            {
                Exception => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
