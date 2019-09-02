﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace ProblemNet
{
    public class ProblemDetailsException : Exception
    {
        /// <summary>
        /// A URI reference [RFC3986] that identifies the problem type. This specification encourages that, when
        /// dereferenced, it provide human-readable documentation for the problem type
        /// (e.g., using HTML [W3C.REC-html5-20141028]).  When this member is not present, its value is assumed to be
        /// "about:blank".
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type.It SHOULD NOT change from occurrence to occurrence
        /// of the problem, except for purposes of localization(e.g., using proactive content negotiation;
        /// see[RFC7231], Section 3.4).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The HTTP status code([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
        public int? Status { get; set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "detail")]
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem.It may or may not yield further information if dereferenced.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Gets the <see cref="T:System.Collections.Generic.IDictionary`2" /> for extension members.
        /// <para>
        /// Problem type definitions MAY extend the problem details object with additional members. Extension members appear in the same namespace as
        /// other members of a problem type.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The round-tripping behavior for <see cref="P:Microsoft.AspNetCore.Mvc.ProblemDetails.Extensions" /> is determined by the implementation of the Input \ Output formatters.
        /// In particular, complex types or collection types may not round-trip to the original type when using the built-in JSON or XML formatters.
        /// </remarks>
        [JsonExtensionData]
        public IDictionary<string, object> Extensions { get; set; } = new Dictionary<string, object>(StringComparer.Ordinal);

        public ProblemDetails ProblemDetails
        {
            get
            {
                var problemDetails = new ProblemDetails()
                                     {
                                             Title = Title,
                                             Detail = Detail,
                                             Instance = Instance,
                                             Status = Status ?? StatusCodes.Status400BadRequest,
                                             Type = Type
                                     };

                foreach (KeyValuePair<string, object> extension in Extensions)
                {
                    problemDetails.Extensions.Add(extension);
                }

                return problemDetails;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Type    : {ProblemDetails.Type}");
            stringBuilder.AppendLine($"Title   : {ProblemDetails.Title}");
            stringBuilder.AppendLine($"Status  : {ProblemDetails.Status}");
            stringBuilder.AppendLine($"Detail  : {ProblemDetails.Detail}");
            stringBuilder.AppendLine($"Instance: {ProblemDetails.Instance}");

            return stringBuilder.ToString();
        }
    }
}
