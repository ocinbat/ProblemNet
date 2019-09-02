using System;

using Microsoft.AspNetCore.Http;

namespace ProblemNet
{
    public class ProblemDetailsOptions
    {
        public string DefaultTypeBaseUri { get; set; }

        public Func<HttpContext, bool> DisplayUnhandledExceptionDetails { get; set; }
    }
}
