using System.Collections.Generic;
using System.Linq;

namespace ProblemNet
{
    public class ValidationProblem
    {
        public string Field { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public ValidationProblem()
        {
        }

        public ValidationProblem(string field, params string[] messages)
        {
            Field = field;
            Messages = messages.ToList();
        }
    }
}