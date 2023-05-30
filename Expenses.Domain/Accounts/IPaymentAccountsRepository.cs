using SharedKernel.Domain.Abstractions;

namespace Expenses.Domain.Accounts;

public interface IPaymentAccountsRepository : IReadRepository<PaymentAccount>
{
}
