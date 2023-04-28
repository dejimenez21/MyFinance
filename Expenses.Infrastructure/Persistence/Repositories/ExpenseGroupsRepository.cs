using Expenses.Domain.ExpenseGroups;
using SharedKernel.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories
{
    public class ExpenseGroupsRepository : CommandsRepository<ExpensesDbContext, ExpenseGroup>, IExpenseGroupsRepository
    {
        public ExpenseGroupsRepository(ExpensesDbContext context) : base(context)
        {
            
        }
    }
}
