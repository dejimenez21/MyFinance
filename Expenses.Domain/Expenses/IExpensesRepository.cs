using SharedKernel.Domain.Abstractions;

namespace Expenses.Domain.Expenses;

public interface IExpensesRepository : ICommandRepository<Expense>
{
}
