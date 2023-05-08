using Api.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ISender _sender;

        public BaseController(ISender sender)
        {
            _sender = sender;
        }
        protected ActionResult<T> FromResult<T>(Result<T> result)
        {
            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return new ObjectResult(result.Error?.ToProblemDetails());
            }
        }
    }
}
