using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProblemNet.Problems;

namespace ProblemNet.Exceptions
{
    public class ValidationProblemDetailsException : ProblemDetailsException
    {
        /// <summary>
        /// Gets the validation errors associated with this instance of <see cref="T:Microsoft.AspNetCore.Mvc.ValidationProblemDetails" />.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);

        public ValidationProblemDetailsException(params ValidationProblem[] validationProblems)
        {
            if (validationProblems == null)
            {
                throw new ArgumentNullException(nameof(validationProblems));
            }

            Errors = validationProblems.ToDictionary(p => p.Field, p => p.Messages.ToArray());

            Status = StatusCodes.Status400BadRequest;
            Type = $"https://httpstatuses.com/400";
            Detail = "Model State Validation";
        }

        public ValidationProblemDetailsException(string field, params string[] messages)
                : this(new ValidationProblem(field, messages))
        {
        }
    }
}