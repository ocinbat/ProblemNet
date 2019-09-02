using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace ProblemNet
{
    public static class ProblemDetailsServiceCollectionExtensions
    {
        public static void AddProblemDetails(this IServiceCollection services,
                                             Action<ProblemDetailsOptions> setupAction = null)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<ProblemDetailsOptions>, ProblemDetailsOptionsConfigurator>());
            if (setupAction != null)
                services.ConfigureSwaggerGen(setupAction);
        }

        public static void ConfigureSwaggerGen(
                this IServiceCollection services,
                Action<ProblemDetailsOptions> setupAction)
        {
            services.Configure<ProblemDetailsOptions>(setupAction);
        }
    }
}
