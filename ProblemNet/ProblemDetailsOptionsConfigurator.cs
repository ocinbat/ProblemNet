using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ProblemNet
{
    public class ProblemDetailsOptionsConfigurator : IConfigureOptions<ProblemDetailsOptions>
    {
        public void Configure(ProblemDetailsOptions options)
        {
            if (options.DisplayUnhandledExceptionDetails == null)
            {
                options.DisplayUnhandledExceptionDetails = DisplayUnhandledExceptionDetails;
            }
        }

        private static bool DisplayUnhandledExceptionDetails(HttpContext context)
        {
            return false;
            return context.RequestServices.GetRequiredService<IHostingEnvironment>().IsDevelopment();
        }
    }
}
