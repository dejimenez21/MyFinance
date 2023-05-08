using Expenses.Application.UseCases.ExpenseGroups.List;
using Expenses.Domain.ExpenseGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ExpenseGroupsController : BaseController
{
    public ExpenseGroupsController(ISender sender) : base(sender) { }

    [HttpGet]
    public async Task<ActionResult<List<ExpenseGroup>>> GetExpenseGroupsInfo()
    {
        var response = await _sender.Send(new ListExpenseGroupsQuery());
        return FromResult(response);
    }
}
