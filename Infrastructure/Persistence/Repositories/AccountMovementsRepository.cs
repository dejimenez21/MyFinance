using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountMovementsRepository : BaseRepository<AccountMovement>, IAccountMovementsRepository
    {
        public AccountMovementsRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<AccountMovement>> GetMovementsByAccountId(Guid accountId)
        {
            return await _context.AccountMovements.Where(m => m.AccountId == accountId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AccountMovement>> GetMovementsByMultipleAccountIds(IEnumerable<Guid> accountIds)
        {
            return await _context.AccountMovements.Where(m => accountIds.Contains(m.AccountId)).AsNoTracking().ToListAsync();
        }
    }
}
