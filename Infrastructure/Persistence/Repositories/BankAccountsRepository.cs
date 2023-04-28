using Domain.Abstractions;
using Domain.Entities;
using SharedKernel.Persistence;

namespace Infrastructure.Persistence.Repositories
{
    public class BankAccountsRepository : CommandsRepository<TransactionsDbContext, CreditCard>, IBankAccountsRepository
    {
        public BankAccountsRepository(TransactionsDbContext context) : base(context)
        {
        }
    }
}
