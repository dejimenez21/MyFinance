using Expenses.Domain.Accounts;
using SharedKernel.Infrastructure.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories
{
    public sealed class AccountsRepository : CommandsRepository<ExpensesDbContext, PaymentAccount>, IPaymentAccountsRepository
    {
        public AccountsRepository(ExpensesDbContext context) : base(context)
        {
        }

    }
}