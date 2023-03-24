using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class ExpensesRepository : CommandsRepository<Expense>, IExpensesRepository
    {
        public ExpensesRepository(AppDbContext context) : base(context) { }

    }
}
