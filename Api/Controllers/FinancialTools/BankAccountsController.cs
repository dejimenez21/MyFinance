using FinancialTools.Application.UseCases.BankAccounts.Create;
using FinancialTools.Domain.BankAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.FinancialTools;

[ApiController]
[Route("api/[controller]")]
public class BankAccountsController : BaseController
{
    public BankAccountsController(ISender sender) : base(sender) { }

    [HttpPost]
    public async Task<ActionResult<BankAccount>> PostBankAccount(CreateBankAccountCommand command)
    {
        var result = await _sender.Send(command);
        return FromResult(result);
    }
}
