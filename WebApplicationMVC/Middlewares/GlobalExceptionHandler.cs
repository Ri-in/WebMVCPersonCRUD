using FluentValidation;
using FluentValidation.Results;
using System.Text.Json;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }

            
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = GetStatusCode(ex);

            var response = context.Response;
            

            response.ContentType = "application/json";
            response.StatusCode = GetStatusCode(ex);
            ErrorDetails errorDetails = new ErrorDetails()
            {
                Message = ex.Message,
                StatusCode = response.StatusCode
            };

            string result = JsonSerializer.Serialize(errorDetails);

            await response.WriteAsJsonAsync(result);
        }

        private static int GetStatusCode(Exception ex)
        {
            return ex switch
            {
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private static IEnumerable<ValidationFailure> GetErrors(Exception ex)
        {
            IEnumerable<ValidationFailure> errors = null;

            if (ex is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
