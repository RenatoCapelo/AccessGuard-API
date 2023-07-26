using AcessGuard_API.Exceptions;

namespace AcessGuard_API.Middleware
{
    public class AccessGuardExceptionMiddleware:IMiddleware
    {
        //private readonly ErrorRepository _errorRepository;

        //public AccessGuardExceptionMiddleware()
        //{
            
        //}
        

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(AccessGuardException ex)
            {

            }
        }
    }
}
