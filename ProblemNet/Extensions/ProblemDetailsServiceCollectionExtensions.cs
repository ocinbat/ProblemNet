using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ProblemNet.Options;

namespace ProblemNet.Extensions
{
    public static class ProblemDetailsServiceCollectionExtensions
    {
        public static void AddProblemDetails(this IServiceCollection services,
                                             Action<ProblemDetailsOptions> setupAction = null)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<ProblemDetailsOptions>, ProblemDetailsOptionsConfigurator>());
            if (setupAction != null)
                services.ConfigureProblemDetailsOptions(setupAction);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Type = $"https://httpstatuses.com/400",
                        Detail = "Model State Validation"
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                        {
                            "application/problem+json",
                            "application/problem+xml"
                        }
                    };
                };
            });
        }

        public static void ConfigureProblemDetailsOptions(
                this IServiceCollection services,
                Action<ProblemDetailsOptions> setupAction)
        {
            services.Configure<ProblemDetailsOptions>(setupAction);
        }
    }
}
