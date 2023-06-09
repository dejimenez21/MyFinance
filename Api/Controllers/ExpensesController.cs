using Expenses.Application.UseCases.Expenses.Create;
using Expenses.Application.UseCases.Expenses.List;
using Expenses.Domain.Expenses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Primitives;

namespace Api.Controllers
{
    public class ExpensesController : BaseController
    {
        public ExpensesController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return await _sender.Send(new ListExpensesQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(CreateExpenseCommandV1 expense)
        {
            var result = await _sender.Send(expense);
            return FromResult(result);
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<ExpenseCategory>> GetExpenseCategories()
        {
            return Ok(Enumeration.GetAll<ExpenseCategory>());
        }

    }
}