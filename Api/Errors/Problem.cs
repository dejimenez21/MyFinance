using Microsoft.AspNetCore.Mvc;

namespace Api.Errors
{
    public class Problem : ProblemDetails
    {
        public IEnumerable<ProblemDetails> Errors { get; set; }
    }
}
