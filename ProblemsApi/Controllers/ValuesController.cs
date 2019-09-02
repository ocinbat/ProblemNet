using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ProblemNet;

namespace ProblemsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public ActionResult<IEnumerable<string>> Get()
        {
            new ProblemDetails()
            {
                Type = "user-not-exists",
                Status = (int)HttpStatusCode.NotFound,
                Detail = "Users cannot be found"
            };
            throw new ProblemDetailsException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserNotFoundProblem), 404)]
        public ActionResult<string> Get(int id)
        {
            new UserNotFoundProblem()
            {
                Status = (int)HttpStatusCode.NotFound,
                Title = $"Users cannot be found",
                UserId = id
            };
            throw new ProblemDetailsException();
        }

        [HttpGet("{id}/orders")]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public ActionResult<string> GetUserOrders(int id)
        {
            var problemDetails = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.NotFound,
                Title = $"Users cannot be found",
                Extensions =
                                         {
                                                 new KeyValuePair<string, object>("Order Data", "User orders is empty"),
                                                 new KeyValuePair<string, object>("UserId", id)
                                         }
            };
            throw new ProblemDetailsException();
        }

        [HttpGet("{id}/browsing-histories")]
        [ProducesResponseType(500)]
        public void GetUserBrowsingHistory(int id)
        {
            throw new NullReferenceException();
        }

        [HttpGet("{id}/notes")]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public ActionResult<string> GetUserNotes(int id)
        {
            var validationProblemDetails = new ValidationProblemDetails()
            {
                Detail = "Error while creating account. Please see errors for detail.",
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Register Error"
            };

            throw new ValidationProblemDetailsException("", "Email address length must be greater than 5 characters", "Email address must be email format");
        }
    }
}
