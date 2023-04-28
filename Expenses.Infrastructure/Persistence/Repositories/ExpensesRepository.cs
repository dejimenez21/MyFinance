using Domain.Abstractions;
using Expenses.Domain.ExpenseGroups;
using SharedKernel.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories
{
    public class ExpensesRepository : ReadOnlyRepository<ExpensesDbContext, Expense>, IExpensesRepository
    {
        public ExpensesRepository(ExpensesDbContext context) : base(context) { }

    }
}
