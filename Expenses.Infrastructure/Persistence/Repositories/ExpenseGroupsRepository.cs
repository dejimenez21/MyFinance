using Expenses.Domain.ExpenseGroups;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories;

public class ExpenseGroupsRepository : CommandsRepository<ExpensesDbContext, ExpenseGroup>, IExpenseGroupsRepository
{
    public ExpenseGroupsRepository(ExpensesDbContext context) : base(context)
    {
        
    }

    public async Task<bool> ExistsAsync(Guid groupId) => 
        await _context.ExpenseGroups.AnyAsync(g => g.Id == groupId);
}
