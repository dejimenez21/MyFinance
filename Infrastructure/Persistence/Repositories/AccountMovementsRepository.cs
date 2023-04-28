using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Persistence;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountMovementsRepository : ReadOnlyRepository<TransactionsDbContext, AccountEntry>, IAccountMovementsRepository
    {
        public AccountMovementsRepository(TransactionsDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<AccountEntry>> GetMovementsByAccountId(Guid accountId)
        {
            return await _context.AccountMovements.Where(m => m.AccountId == accountId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AccountEntry>> GetMovementsByMultipleAccountIds(IEnumerable<Guid> accountIds)
        {
            return await _context.AccountMovements.Where(m => accountIds.Contains(m.AccountId)).AsNoTracking().ToListAsync();
        }
    }
}
