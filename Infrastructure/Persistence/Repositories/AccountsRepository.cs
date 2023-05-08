using Application.Domain.Enums;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Persistence;

namespace Infrastructure.Persistence.Repositories;

public class AccountsRepository : CommandsRepository<TransactionsDbContext, Account>, IAccountsRepository
{
    public AccountsRepository(TransactionsDbContext context) : base(context)
    {
    }

    public async Task<Account?> GetAcccountByName(string name)
    {
        return await GetWithIncludeAll().FirstOrDefaultAsync(a => a.Name == name);
    }

    public async Task<List<Account>> GetCashAccounts()
    {
        return await GetWithIncludeAll().Where(a => a.IsCash && a.Type == AccountType.Asset).ToListAsync();
    }
}