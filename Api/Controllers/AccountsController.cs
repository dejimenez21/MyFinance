using Application.Dtos;
using Application.UseCases.Accounts.ListLiquidAccounts;
using Expenses.Application.UseCases.PaymentAccounts.List;
using Expenses.Domain.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AccountsController : BaseController
    {
        public AccountsController(ISender sender) : base(sender) { }

        [HttpGet("liquidity")]
        public async Task<ActionResult<LiquidAccountDto>> GetLiquidAccounts([FromQuery]bool onlyPaymentElegible=false)
        {
            var liquidAccounts = await _sender.Send(new ListLiquidAccountsQuery { OnlyPaymentElegible = onlyPaymentElegible });

            return Ok(liquidAccounts);
        }

        [HttpGet("payment-accounts")]
        public async Task<ActionResult<PaymentAccount>> GetPaymentAccounts()
        {
            return Ok(await _sender.Send(new ListPaymentAccountsQuery()));
        }
    }
}
