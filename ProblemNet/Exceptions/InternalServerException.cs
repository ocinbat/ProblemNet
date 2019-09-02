using System;
using Microsoft.AspNetCore.Http;
using ProblemNet.Problems;

namespace ProblemNet.Exceptions
{
    public class InternalServerException : StatusCodeProblemDetails
    {
        public InternalServerException(Exception error, bool displayExceptionDetail = false)
                :
                this(error, StatusCodes.Status500InternalServerError, displayExceptionDetail: displayExceptionDetail)
        {
        }

        private InternalServerException(Exception error, int statusCode, bool displayExceptionDetail = false)
                : base(statusCode)
        {
            Error = displayExceptionDetail ? error : null;
            Detail = "An error occurred while processing your request";
        }

        public Exception Error { get; }
    }
}
