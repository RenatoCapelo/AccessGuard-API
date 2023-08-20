using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Repositories.Errors;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AccessGuard_API.Middleware
{
    public class AccessGuardExceptionMiddleware:IMiddleware
    {
        private readonly IErrorRepository _errorRepository;

        public AccessGuardExceptionMiddleware(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(AccessGuardException ex)
            {
                string errorCode = ex.Message;
                Error? errorDb = _errorRepository.GetError(errorCode);
                
                context.Response.StatusCode = errorDb?.HttpStatusCode ?? StatusCodes.Status418ImATeapot;
                context.Response.ContentType = "application/json";

                ErrorDetails errorDetails = new ErrorDetails();
                errorDetails.ErrorCode = errorCode;
                errorDetails.ErrorMessage = errorDb?.ErrorMessage ?? "We still have not information regarding this error, please contact support";

                var jsonResponse = JsonSerializer.Serialize(errorDetails);
                await context.Response.WriteAsync(jsonResponse);
                
            }
        }
    }
}
