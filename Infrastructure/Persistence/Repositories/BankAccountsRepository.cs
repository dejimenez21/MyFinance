using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class BankAccountsRepository : CommandsRepository<CreditCard>, IBankAccountsRepository
    {
        public BankAccountsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
