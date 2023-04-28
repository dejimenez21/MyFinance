using SharedKernel.Domain.Abstractions;

namespace Expenses.Domain.ExpenseGroups
{
    public interface IExpenseGroupsRepository : ICommandRepository<ExpenseGroup>
    {
    }
}
