using Application.Domain.Enums;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountsRepository : CommandsRepository<Account>, IAccountRepository
    {
        public AccountsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Account>> GetCashAccounts()
        {
            return await _context.Accounts.Where(a => a.IsCash && a.Type == AccountType.Asset).ToListAsync();
        }
    }
}