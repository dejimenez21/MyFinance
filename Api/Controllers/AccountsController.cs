using Application.Dtos;
using Application.UseCases.Accounts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AccountsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("liquidity")]
        public async Task<ActionResult<LiquidAccountDto>> GetLiquidAccounts([FromQuery]bool onlyPaymentElegible=false)
        {
            var liquidAccounts = await _mediatr.Send(new GetLiquidAccountsSummary.Query { OnlyPaymentElegible = onlyPaymentElegible });

            return Ok(liquidAccounts);
        }
    }
}
