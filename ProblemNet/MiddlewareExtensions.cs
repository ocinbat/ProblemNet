using Microsoft.AspNetCore.Builder;

namespace ProblemNet
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ProblemDetailsMiddleware>();
        }
    }
}
