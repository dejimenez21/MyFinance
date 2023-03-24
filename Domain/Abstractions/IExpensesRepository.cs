using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IExpensesRepository : ICommandRepository<Expense>, IRepository<Expense>
    {
    }
}
