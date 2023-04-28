using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SharedKernel.Common;

namespace Api.Errors
{
    public static class ErrorExtensions
    {
        public static Problem ToProblemDetails(this Error error)
        {
            return new Problem
            {
                Title = error.ErrorCode,
                Detail = error.Message,
                Status = error.StatusCode,
                Errors = error.Reasons.Select(r => new ProblemDetails { Title = r.ErrorCode, Detail = r.Message })
            };
        }
    }
}
