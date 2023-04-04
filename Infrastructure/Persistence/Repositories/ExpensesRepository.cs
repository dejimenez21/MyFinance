using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Repositories.Shared;

namespace Infrastructure.Persistence.Repositories
{
    public class ExpensesRepository : CommandsRepository<Expense>, IExpensesRepository
    {
        public ExpensesRepository(AppDbContext context) : base(context) { }

    }
}
