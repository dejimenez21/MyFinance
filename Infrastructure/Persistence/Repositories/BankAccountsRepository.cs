using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Repositories.Shared;

namespace Infrastructure.Persistence.Repositories
{
    public class BankAccountsRepository : CommandsRepository<CreditCard>, IBankAccountsRepository
    {
        public BankAccountsRepository(TransactionsDbContext context) : base(context)
        {
        }
    }
}
