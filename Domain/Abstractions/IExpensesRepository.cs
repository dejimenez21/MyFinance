using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IExpensesRepository : ICommandRepository<Expense>, IRepository<Expense>
    {
    }
}
