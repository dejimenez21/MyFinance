using Expenses.Domain.Expenses;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IExpensesRepository : ICommandRepository<Expense>, IRepository<Expense>
    {
    }
}
