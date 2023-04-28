using Expenses.Application.Dtos;
using Expenses.Application.UseCases.Expenses;
using Expenses.Domain.ExpenseGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : BaseController
    {
        public ExpensesController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return await _sender.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(ExpenseCreateDto expense)
        {
            var result = await _sender.Send(new Create.Command { Expense = expense });
            return FromResult(result);
        }
    }
}