using Domain.Abstractions;
using Domain.Entities;
using SharedKernel.Infrastructure.Persistence;

namespace Infrastructure.Persistence.Repositories;

public class BankAccountsRepository : CommandsRepository<TransactionsDbContext, BankAccount>, IBankAccountsRepository
{
    public BankAccountsRepository(TransactionsDbContext context) : base(context)
    {
    }
}
