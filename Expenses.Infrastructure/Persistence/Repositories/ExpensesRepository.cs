using Domain.Abstractions;
using Expenses.Domain.Expenses;
using SharedKernel.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories
{
    public class ExpensesRepository : CommandsRepository<ExpensesDbContext, Expense>, IExpensesRepository
    {
        public ExpensesRepository(ExpensesDbContext context) : base(context) { }

    }
}
