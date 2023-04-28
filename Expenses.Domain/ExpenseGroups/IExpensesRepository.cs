using Expenses.Domain.ExpenseGroups;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IExpensesRepository : IReadOnlyRepository<Expense>
    {
    }
}
